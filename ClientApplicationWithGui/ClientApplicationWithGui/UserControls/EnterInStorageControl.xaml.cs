using ClientApplication.ControllerClasses;
using ClientApplicationWithGui.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ClientApplicationWithGui.UserControls
{
    /// <summary>
    /// Interaction logic for EnterInStorageControl.xaml
    /// </summary>
    public partial class EnterInStorageControl : UserControl
    {
        private Storage storageChosen;
        public ObservableCollection<StorageItem> storageItems;
        public ICollectionView storageItemsRecord;

        private void ExistFromStorage()
        {
            EmptyProductFields();
            DisableProductProcessingRequest();
            storageItems.Clear();
            cmbMenu.IsEnabled = false;
            lblEnteredStorage.Content = string.Empty;
        }

        private void EmptyProductFields()
        {
            tfNameOfProduct.Text = string.Empty;
            tfUnitCostOfProduct.Text = string.Empty;
            tfCountOfProduct.Text = string.Empty;
        }

        private void DisableProductProcessingRequest()
        {
            tfNameOfProduct.IsEnabled = false;
            tfUnitCostOfProduct.IsEnabled = false;
            tfCountOfProduct.IsEnabled = false;
            btnProcessProductRequest.IsEnabled = true;
        }

        private void EnableProductProcessingForReadAndDeleteRequest()
        {
            EmptyProductFields();
            tfNameOfProduct.IsEnabled = true;
            tfUnitCostOfProduct.IsEnabled = false;
            tfCountOfProduct.IsEnabled = false;
            btnProcessProductRequest.IsEnabled = true;
        }
        private void EnableProductProcessingForCreateAndUpdateRequest()
        {
            EmptyProductFields();
            tfNameOfProduct.IsEnabled = true;
            tfUnitCostOfProduct.IsEnabled = true;
            tfCountOfProduct.IsEnabled = true;
            btnProcessProductRequest.IsEnabled = true;
        }
        public EnterInStorageControl()
        {
            InitializeComponent();
            cmbMenu.IsEnabled = false;
            storageItems = new ObservableCollection<StorageItem>();
            storageItemsRecord = CollectionViewSource.GetDefaultView(storageItems);
            if (storageItemsRecord != null)
            {
                dataGridStorage.ItemsSource = storageItemsRecord;
            }
            DisableProductProcessingRequest();
        }

        private void btnEnterInExistingStorage_Click(object sender, RoutedEventArgs e)
        {
            string name = tfNameOfStorage.Text;
            string key = string.Empty;
            Parameters.storageManager.SendRequestForStorageKey(name);
            key = Parameters.storageManager.GetStorageKey();
            this.storageChosen = Parameters.storageManager[key].Clone() as Storage;

            MessageBox.Show("You are now in storage " + storageChosen.Name + " [" + storageChosen.Kind + "]");
            lblEnteredStorage.Content = "Storage Menu for " + storageChosen.Name + " [" + storageChosen.Kind + "] :";
            cmbMenu.IsEnabled = true;
        }

        private void cmbMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cmbMenu.SelectedItem.ToString().Contains("Create new product"))
            {
                EnableProductProcessingForCreateAndUpdateRequest();
            }

            if (cmbMenu.SelectedItem.ToString().Contains("Read existing product"))
            {
                EnableProductProcessingForReadAndDeleteRequest();
            }

            if (cmbMenu.SelectedItem.ToString().Contains("Update existing product"))
            {
                EnableProductProcessingForCreateAndUpdateRequest();
            }

            if (cmbMenu.SelectedItem.ToString().Contains("Delete existing product"))
            {
                EnableProductProcessingForReadAndDeleteRequest();
            }

            if (cmbMenu.SelectedItem.ToString().Contains("Get min cost of products"))
            {
                DisableProductProcessingRequest();
                double min = 0;
                this.storageChosen.SendRequestForProductsCostMin();
                Product productMin = storageChosen.GetResponseForProductsCostMin(out min);

                MessageBox.Show("Min for this storage is : " + min + System.Environment.NewLine + "Name of product is : " + productMin.Name + System.Environment.NewLine + "Unit cost of product is : " + productMin.Cost + System.Environment.NewLine + "Count of product is : " + productMin.Count);
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Get max cost of products"))
            {
                DisableProductProcessingRequest();
                double max = 0;
                this.storageChosen.SendRequestForProductsCostMax();
                Product productMax = storageChosen.GetResponseForProductsCostMax(out max);

                MessageBox.Show("Min for this storage is : " + max + System.Environment.NewLine + "Name of product is : " + productMax.Name + System.Environment.NewLine + "Unit cost of product is : " + productMax.Cost + System.Environment.NewLine + "Count of product is : " + productMax.Count);
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Get average cost of products"))
            {
                DisableProductProcessingRequest();
                double average = 0.0;
                this.storageChosen.SendRequestForProductsCostAvg();
                average = this.storageChosen.GetResponseForProductsCostAvg();

                MessageBox.Show("Average cost for this storage is : " + average);
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Get sum cost of all products"))
            {
                DisableProductProcessingRequest();
                double sum = 0.0;
                this.storageChosen.SendRequestForProductsCostSum();
                sum = this.storageChosen.GetResponseForProductsCostSum();

                MessageBox.Show("Sum cost for this storage is : " + sum);
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Display state of current storage"))
            {
                DisableProductProcessingRequest();
                this.storageChosen.SendRequestForState();
                this.storageChosen.GetStorageItems();

                storageItems.Clear();
                foreach (StorageItem storageItem in storageChosen.StorageItems)
                {
                    storageItems.Add(storageItem);
                }
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Exit from storage"))
            {
                ExistFromStorage();
            }
        }

        private void btnProcessProductRequest_Click(object sender, RoutedEventArgs e)
        {

            if (cmbMenu.SelectedItem.ToString().Contains("Create new product"))
            {
                string nameOfProduct = tfNameOfProduct.Text;
                string unitCostString = tfUnitCostOfProduct.Text;
                string countString = tfCountOfProduct.Text;
                double unitCost = 0;
                bool isNUnitCost = double.TryParse(unitCostString, out unitCost);
                if (isNUnitCost == false)
                {
                    MessageBox.Show("Unit cost of Product must be number !!!");
                }
                int count = 0;
                bool isNCount = int.TryParse(countString, out count);
                if (isNCount == false)
                {
                    MessageBox.Show("Count of Product must be number !!!");
                }
                if (isNUnitCost == true && isNCount == true)
                {
                    bool isProductAlreadyExist = false;
                    Product newProduct = new Product(nameOfProduct, unitCost, count);
                    storageChosen.SendRequestForProductCheck(newProduct.Name);
                    isProductAlreadyExist = storageChosen.GetResponseForProductCheck();
                    if (isProductAlreadyExist == false)
                    {
                        storageChosen.SendRequestForAddedNewProduct(newProduct);
                        MessageBox.Show("Product with name " + newProduct.Name + " successfully is entered in current storage !!!");
                    }
                    else
                    {
                        MessageBox.Show("Product with name " + newProduct.Name + " already exist in current storage !!!");
                    }
                }
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Read existing product"))
            {
                string nameOfProduct = tfNameOfProduct.Text;
                this.storageChosen.SendRequestForProductInfo(nameOfProduct);
                Product productChosen = this.storageChosen.GetProductInfo();
                if (productChosen.Name.Equals(string.Empty) == false)
                {
                    MessageBox.Show("Name : " + productChosen.Name + System.Environment.NewLine + "Cost of unit : " + productChosen.Cost + System.Environment.NewLine + "Count : " + productChosen.Count);
                }
                else
                {
                    MessageBox.Show(System.Environment.NewLine + "Product with name " + nameOfProduct + " doesn't exist in this storage !!!");
                }
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Update existing product"))
            {
                string nameOfProduct = tfNameOfProduct.Text;
                string costOfProductString = tfUnitCostOfProduct.Text;
                string countOfProductString = tfCountOfProduct.Text;
                double costOfProduct = 0.0;
                bool isNUnitCost = double.TryParse(costOfProductString, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out costOfProduct);
                int countOfProduct = 0;
                bool isNCount = int.TryParse(countOfProductString, out countOfProduct);
                if (isNUnitCost == true && isNCount == true)
                {
                    Product updateProduct = new Product(nameOfProduct, costOfProduct, countOfProduct);

                    storageChosen.SendRequestForUpdateProduct(updateProduct);
                    MessageBox.Show("Product with name " + updateProduct.Name + " successfully is updated in current storage !!!");
                }
            }
            if (cmbMenu.SelectedItem.ToString().Contains("Delete existing product"))
            {
                string nameOfProduct = tfNameOfProduct.Text;

                storageChosen.SendRequestForDeleteProduct(nameOfProduct);
                MessageBox.Show("Product with name " + nameOfProduct + " successfully is deleted in current storage !!!");
            }

        }
    }
}
