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

namespace ClientApplicationWithGui
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            Console.WriteLine("Loading storages info ...");
            Parameters.storageManager = StorageManager.Instance;
            //initialize with storages
            Parameters.storageManager.SendRequestForExistingStorages();
            List<string> storages = Parameters.storageManager.gettingStorages();
            foreach (string item in storages)
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


            Parameters.bufferAddress = BufferAddress.GetInstance(Parameters.pathForRequest, Parameters.pathForResponse);
        }
       
    }
}
