using ClientApplication.ControllerClasses;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    /// Interaction logic for StoragesListInSystemControl.xaml
    /// </summary>
    public partial class StoragesListInSystemControl : UserControl
    {

        public List<string> storagesNames;
        public ObservableCollection<Storage> storages;
        public ICollectionView cvsRecord;

        public StoragesListInSystemControl()
        {
            InitializeComponent();
            storages = new ObservableCollection<Storage>();

            cvsRecord = CollectionViewSource.GetDefaultView(storages);
            if (cvsRecord != null)
            {
                dataGridStorages.ItemsSource = cvsRecord;
            }
        }

        private void btnEnterNewStorage_Click(object sender, RoutedEventArgs e)
        {
            Parameters.storageManager.SendRequestForExistingStorages();
            storagesNames = Parameters.storageManager.gettingStorages();
            foreach (string item in storagesNames)
            {
                string name = string.Empty;
                string kind = string.Empty;
                List<string> storageParts = item.Split(' ').ToList();
                if (storageParts.Count == 2)
                {
                    name = storageParts[0];
                    kind = storageParts[1];
                    Parameters.storageManager[name + kind] = new Storage(name, kind);
                }
            }

            storages.Clear();
            foreach (var storagePrototype in Parameters.storageManager.StorageInSystem)
            {
                Storage storage = storagePrototype.Value.Clone() as Storage;

                storages.Add(storage);
            }
        }
    }
}
