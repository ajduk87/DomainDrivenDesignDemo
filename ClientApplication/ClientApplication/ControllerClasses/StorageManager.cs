using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceProcess;
using System;
using System.Threading;

namespace ClientApplication.ControllerClasses
{
    public class StorageManager
    {
        private static StorageManager instance;
        private Dictionary<string, StoragePrototype> _storagesInSystem;

        private bool IHaveResponse = false;
        List<string> responseList;


        public StorageManager() 
        {
            _storagesInSystem = new Dictionary<string, StoragePrototype>();           
        }

        public static StorageManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new StorageManager();
                }
                return instance;
            }
        }

        #region methodsForGettingResponse

        private void setTimeoutSettings()
        {
            Program.IsTimeoutHappened = false;
            Program.Timeout = 500 * 60;// 30 seconds
        }


        public List<string> gettingStorages() 
        {
            setTimeoutSettings();
            IHaveResponse = false;
            responseList = new List<string>();

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    IHaveResponse = true;
                    truncateResponseFile();
                }
                Thread.Sleep(500);

                Program.Timeout = Program.Timeout - 500;
            }

            if (Program.Timeout <= 0)
            {
                Console.WriteLine("Service wasn't responded !!! Timeout was elapsed !!!");
            }

            return responseList;

        }

       

        public string GetStorageKey() 
        {
            setTimeoutSettings();
            IHaveResponse = false;
            responseList = new List<string>();

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    IHaveResponse = true;
                    truncateResponseFile();
                }
                Thread.Sleep(500);

                Program.Timeout = Program.Timeout - 500;
            }

            if (Program.Timeout <= 0)
            {
                Console.WriteLine("Service wasn't responded !!! Timeout was elapsed !!!");
            }

            return responseList[0];
        } 

       

        private void truncateResponseFile()
        {
            // Delete data from the Transaction.tmp file
            FileStream fs = new FileStream(Program.bufferAddress.PathForResponseBuff, FileMode.Truncate);
            fs.Flush();
            fs.Close();
        }

        #endregion

        #region methodsForSendingRequest


        public void SendRequestForExistingStorages() 
        {
            _storagesInSystem.Clear();

            Program.bufferAddress = BufferAddress.GetInstance(Program.pathForRequest, Program.pathForResponse);
            _storagesInSystem = new Dictionary<string, StoragePrototype>();           
            string request = "GET STORAGE";
            executeRequest(request);
        }

        public void SendRequestForStorageKey(string name)
        {
            string request = "GET STORAGE " + name;
            executeRequest(request);
        }

        private void executeRequest(string request) 
        {
            List<string> listOfRequests = new List<string>();
            listOfRequests.Add(request);
            File.AppendAllLines(Program.bufferAddress.PathForRequestBuff, listOfRequests);

            ServiceController sc = new ServiceController("DDDDemoServerService");
            sc.ExecuteCommand(200);
        }

        #endregion

        // Indexer

        public StoragePrototype this[string key]
        {

            get { return _storagesInSystem[key]; }

            set { _storagesInSystem.Add(key, value); }

        }

        public Dictionary<string, StoragePrototype> StorageInSystem 
        {
            get { return _storagesInSystem; }
        }

    }
}
