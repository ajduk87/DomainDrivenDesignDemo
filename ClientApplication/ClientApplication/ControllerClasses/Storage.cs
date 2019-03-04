using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using System.Globalization;

namespace ClientApplication.ControllerClasses
{
    public class Storage : StoragePrototype
    {
        #region members

        private bool IHaveResponse = false;

        private string _name = string.Empty;
        private string _kind = string.Empty;

        private List<Product> _products;
        private List<StorageItem> storageItems;


        #endregion

        #region constructors
        /// <summary>
        /// This constructor is used when storage is created without products
        /// </summary>
        /// <param name="name">Name of storage</param>
        /// <param name="kind">What kind of stuff can storage in particular storage</param>
        public Storage(string name, string kind)
        {
            _name = name;
            _kind = kind;

            _products = new List<Product>();
            
        }
        /// <summary>
        /// This constructor is used when storage is created with products
        /// </summary>
        /// <param name="name">Name of storage</param>
        /// <param name="kind">What kind of stuff can storage in particular storage</param>
        /// <param name="products">What products are in particular storage</param>
        public Storage(string name, string kind, List<Product> products/*, Dictionary<string, int> stateOfStorage*/)
        {
            _name = name;
            _kind = kind;

            _products = products;
           
        }

        #endregion       

        #region methods

        #region methodsForGettingResponse

        private void setTimeoutSettings()
        {
            Program.IsTimeoutHappened = false;
            Program.Timeout = 500 * 60;// 30 seconds
        }
       

        public void GetStorageItems() 
        {
            setTimeoutSettings();
            IHaveResponse = false;
            _products = new List<Product>();
            storageItems = new List<StorageItem>();
            List<string> responseList = new List<string>();

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    responseList = responseList.GetRange(0, responseList.Count - 1);
                    foreach (var item in responseList)
                    {
                        List<string> itemList = item.Split(' ').ToList();
                        string nameOfProduct = itemList[0];
                        int count = 0;
                        bool isN = int.TryParse(itemList[1], out count);
                        StorageItem storageItem = new StorageItem { NameOfProduct = nameOfProduct, CountOfProduct = count };
                        storageItems.Add(storageItem);

                    }
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
        }


        public Product GetProductInfo() 
        {
            setTimeoutSettings();
            Product productInfo = new Product();

            IHaveResponse = false;
            List<string> responseList = new List<string>();

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    List<string> responseParts = responseList[0].Split(' ').ToList();
                    if (responseParts.Count == 3)
                    {
                        string nameOfProduct = responseParts[0];
                        double cost = 0;
                        responseParts[1] = responseParts[1].Replace(',', '.');
                        bool isN = double.TryParse(responseParts[1], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out cost);
                        int count = 0;
                        isN = int.TryParse(responseParts[2], out count);
                        productInfo.Name = nameOfProduct;
                        productInfo.Cost = cost;
                        productInfo.Count = count;
                    }

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

            return productInfo;
        }

        public bool GetResponseForProductCheck() 
        {
            setTimeoutSettings();
            IHaveResponse = false;
            List<string> responseList = new List<string>();
            string isExist = string.Empty;

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    isExist = responseList[0];

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

            if (isExist.Equals("True"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public Product GetResponseForProductsCostMin(out double min)
        {
            setTimeoutSettings();
            Product product = new Product();
            min = 0.0;
            IHaveResponse = false;
            List<string> responseList = new List<string>();
            bool isN = false;

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    List<string> responseParts = responseList[0].Split(' ').ToList();
                    if (responseParts.Count == 4)
                    {
                        responseParts[0] = responseParts[0].Replace(',','.');
                        isN = double.TryParse(responseParts[0], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out min);
                        string name = responseParts[1];
                        double cost = 0.0;
                        responseParts[2] = responseParts[2].Replace(',', '.');
                        isN = double.TryParse(responseParts[2], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out cost);
                        int count = 0;
                        isN = int.TryParse(responseParts[3], out count);
                        product.Name = name;
                        product.Cost = cost;
                        product.Count = count;
                    }

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

            return product;
        }

        public Product GetResponseForProductsCostMax(out double max)
        {
            setTimeoutSettings();
            Product product = new Product();
            max = 0.0;
            IHaveResponse = false;
            List<string> responseList = new List<string>();
            bool isN = false;

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    List<string> responseParts = responseList[0].Split(' ').ToList();
                    if (responseParts.Count == 4)
                    {
                        responseParts[0] = responseParts[0].Replace(',', '.');
                        isN = double.TryParse(responseParts[0], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out max);
                        string name = responseParts[1];
                        double cost = 0.0;
                        responseParts[2] = responseParts[2].Replace(',', '.');
                        isN = double.TryParse(responseParts[2], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out cost);
                        int count = 0;
                        isN = int.TryParse(responseParts[3], out count);
                        product.Name = name;
                        product.Cost = cost;
                        product.Count = count;
                    }

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

            return product;
        }

        public double GetResponseForProductsCostAvg()
        {
            setTimeoutSettings();
            double avg = 0.0;
            IHaveResponse = false;
            List<string> responseList = new List<string>();
            bool isN = false;

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    List<string> responseParts = responseList[0].Split(' ').ToList();
                    if (responseParts.Count == 1)
                    {
                        responseParts[0] = responseParts[0].Replace(',', '.');
                        isN = double.TryParse(responseParts[0], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out avg);
                        
                    }

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

            return avg;
        }

        public double GetResponseForProductsCostSum()
        {
            setTimeoutSettings();
            double sum = 0.0;
            IHaveResponse = false;
            List<string> responseList = new List<string>();
            bool isN = false;

            while (IHaveResponse == false && Program.Timeout > 0)
            {
                responseList = File.ReadAllLines(Program.bufferAddress.PathForResponseBuff).ToList();
                if (responseList.Count > 0)
                {
                    List<string> responseParts = responseList[0].Split(' ').ToList();
                    if (responseParts.Count == 1)
                    {
                        responseParts[0] = responseParts[0].Replace(',', '.');
                        isN = double.TryParse(responseParts[0], System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out sum);

                    }

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

            return sum;
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

        private void executeRequest(string request)
        {
            List<string> listOfRequests = new List<string>();
            listOfRequests.Add(request);
            File.AppendAllLines(Program.bufferAddress.PathForRequestBuff, listOfRequests);

            ServiceController sc = new ServiceController("DDDDemoServerService");
            sc.ExecuteCommand(200);
        }

        public void SendRequestForState()
        {
            string request = "GET STORAGE " + this.Name + " " + this.Kind;
            executeRequest(request);
        }

        public void SendRequestForDeleteProduct(string nameOfProduct)
        {
            string request = "DELETE PRODUCT " + nameOfProduct + " " + this.Name + " " + this.Kind;
            executeRequest(request);
        }

        public void SendRequestForUpdateProduct(Product product)
        {
            string request = "PUT PRODUCT " + product.Name + " " + product.Cost + " " + product.Count + " " + this.Name + " " + this.Kind;
            executeRequest(request);
        }

        public void SendRequestForAddedNewProduct(Product product) 
        {
            string request = "INSERT PRODUCT " + product.Name + " " + product.Cost + " " + product.Count + " " + this.Name + " " + this.Kind;
            executeRequest(request);
        }

       

        public void SendRequestForProductCheck(string productName)
        {
            string request = "GET PRODUCT " + productName + " " + this.Name + " " + "CHECK";
            executeRequest(request);
        }


        public void SendRequestForProductInfo(string productName) 
        {
            string request = "GET PRODUCT " + productName + " " + this.Name;
            executeRequest(request);
        }

        public void SendRequestForProductsCostMin()
        {
            string request = "GET PRODUCTCOSTS " + this.Name + " " + "MIN";
            executeRequest(request);
        }

        public void SendRequestForProductsCostMax()
        {
            string request = "GET PRODUCTCOSTS " + this.Name + " " + "MAX";
            executeRequest(request);
        }

        public void SendRequestForProductsCostAvg()
        {
            string request = "GET PRODUCTCOSTS " + this.Name + " " + "AVG";
            executeRequest(request);
        }

        public void SendRequestForProductsCostSum()
        {
            string request = "GET PRODUCTCOSTS " + this.Name + " " + "SUM";
            executeRequest(request);
        }

        #endregion

        public override StoragePrototype Clone()
        {
            Storage storage = new Storage(this._name, this._kind, this._products);

            return storage;
        }

        #endregion 

        #region properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string Kind
        {
            get { return _kind; }
            set { _kind = value; }
        }

        public List<Product> Products
        {
            get { return _products; }
            set { _products = value; }
        }

        public List<StorageItem> StorageItems
        {
            get { return storageItems; }
            set { storageItems = value; }
        }

        #endregion
    }
}
