using ClientApplication.ControllerClasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceProcess;
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
    /// Interaction logic for CreateStorageControl.xaml
    /// </summary>
    public partial class CreateStorageControl : UserControl
    {
        public CreateStorageControl()
        {
            InitializeComponent();
        }

        private void btnEnterNewStorage_Click(object sender, RoutedEventArgs e)
        {
            Parameters.storageManager[tfNameOfStorage.Text + tfKindOfStorage.Text] = new Storage(tfNameOfStorage.Text, tfKindOfStorage.Text);
            if (File.Exists(Parameters.bufferAddress.PathForRequestBuff) == false)
            {
                File.Create(Parameters.bufferAddress.PathForRequestBuff);
            }
            string request = "INSERT STORAGE " + tfNameOfStorage.Text + " " + tfKindOfStorage.Text;
            List<string> listOfRequests = new List<string>();
            listOfRequests.Add(request);
            File.AppendAllLines(Parameters.bufferAddress.PathForRequestBuff, listOfRequests);

            ServiceController sc = new ServiceController("DDDDemoServerService");
            sc.ExecuteCommand(200);

            MessageBox.Show("You added successfully new storage.");
            tfNameOfStorage.Text = string.Empty;
            tfKindOfStorage.Text = string.Empty;
        }
    }
}
