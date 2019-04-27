using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.ServiceProcess;
using System.IO;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Globalization;
using System.Linq;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Implementations;
using ServerApplication.Services.Interfaces;
using ServerApplication.Services.Implementations;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;

namespace ServerApplication
{
    public partial class DDDDemoServerService : ServiceBase
    {
        private string pathForRequest = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForRequest.txt";
        private string pathForResponse = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForResponse.txt";
        private static string pathForDatabase = "C:\\DomainDrivenDesignDemo\\InfrastructureLayer\\Database\\Storages.accdb";
        private OleDbConnection con;
        private long numberOfClientRequest = 0;
        private Discount discount;



        public DDDDemoServerService()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source = " + pathForDatabase);

            if (!File.Exists(pathForRequest))
            {
                FileStream tfs = File.Create(pathForRequest);
                tfs.Close();
            }
            // Create Customers.db file if it does not exist
            if (!File.Exists(pathForResponse))
            {
                FileStream cfs = File.Create(pathForResponse);
                cfs.Close();
            }
        }

        protected override void OnStop()
        {
            if (con != null)
            {
                con.Close();
            }
        }

        protected override void OnCustomCommand(int command)
        {
            if (command == 200)
            {
                Commit();
            }

        }

        private void Commit()
        {
            string[] requests = File.ReadAllLines(pathForRequest);
            foreach (string request in requests)
            {
                string[] requestParts = request.Split(' ');
                List<string> args = new List<string>();
                for (int i = 2; i < requestParts.Length; i++)
                {
                    args.Add(requestParts[i]);
                }
                Request rq = new Request(requestParts[0], requestParts[1], args);

                if (rq.Verb.Equals("INSERT"))
                {
                    if (rq.Noun.Equals("STORAGE"))
                    {
                        if (rq.Args.Count == 2)
                        {
                            this.numberOfClientRequest = 1;
                            ProcessClientRequest(this.numberOfClientRequest, rq);
                        }

                    }//if (rq.Noun.Equals("STORAGE"))

                    if (rq.Noun.Equals("PRODUCT"))
                    {
                        if (rq.Args.Count == 5)
                        {
                            this.numberOfClientRequest = 2;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                            
                        }
                    }//if (rq.Noun.Equals("PRODUCT"))
                }//if (rq.Verb.Equals("INSERT"))

                if (rq.Verb.Equals("GET"))
                {
                    if (rq.Noun.Equals("STORAGE"))
                    {
                        if (rq.Args.Count == 0)
                        {
                            this.numberOfClientRequest = 3;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                            
                        }//end if (rq.Args.Count == 0)
                        if (rq.Args.Count == 1)
                        {
                            this.numberOfClientRequest = 4;
                            ProcessClientRequest(this.numberOfClientRequest, rq);
                        }//end if (rq.Args.Count == 1)
                        if (rq.Args.Count == 2)
                        {
                            this.numberOfClientRequest = 5;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                            
                        }//end if (rq.Args.Count == 2)
                    }//if (rq.Noun.Equals("STORAGE"))

                    if (rq.Noun.Equals("PRODUCT"))
                    {
                        if (rq.Args.Count == 2)
                        {
                            this.numberOfClientRequest = 6;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                            
                        }//if (rq.Args.Count == 2)

                        if (rq.Args.Count == 3 && rq.Args[2].Equals("CHECK"))
                        {
                            this.numberOfClientRequest = 7;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                            
                        }//if (rq.Args.Count == 3)
                    }//if (rq.Noun.Equals("PRODUCT"))

                    if (rq.Noun.Equals("PRODUCTCOSTS"))
                    {
                        if (rq.Args.Count == 2 && rq.Args[1].Equals("MIN"))
                        {
                            this.numberOfClientRequest = 8;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                           

                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("MIN"))

                        if (rq.Args.Count == 2 && rq.Args[1].Equals("MAX"))
                        {
                            this.numberOfClientRequest = 9;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                            
                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("MAX"))

                        if (rq.Args.Count == 2 && rq.Args[1].Equals("AVG"))
                        {
                            this.numberOfClientRequest = 10;
                            ProcessClientRequest(this.numberOfClientRequest, rq);
                            
                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("AVG"))

                        if (rq.Args.Count == 2 && rq.Args[1].Equals("SUM"))
                        {
                            this.numberOfClientRequest = 11;
                            ProcessClientRequest(this.numberOfClientRequest, rq);
                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("SUM"))
                    }//if (rq.Noun.Equals("PRODUCTCOSTS"))

                }//if (rq.Verb.Equals("GET"))

                if (rq.Verb.Equals("PUT"))
                {
                    if (rq.Noun.Equals("PRODUCT"))
                    {
                        if (rq.Args.Count == 5)
                        {
                            this.numberOfClientRequest = 12;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                           
                        }//if (rq.Args.Count == 5)
                    }//if (rq.Noun.Equals("PRODUCT"))
                }//if (rq.Verb.Equals("PUT"))

                if (rq.Verb.Equals("DELETE"))
                {
                    if (rq.Noun.Equals("PRODUCT"))
                    {
                        if (rq.Args.Count == 3)
                        {
                            this.numberOfClientRequest = 13;
                            ProcessClientRequest(this.numberOfClientRequest, rq);                           
                        }//if (rq.Args.Count == 3)
                    }//if (rq.Noun.Equals("PRODUCT"))
                }//if (rq.Verb.Equals("DELETE")) 

            }
            truncateRequestFile();
        }

        private void ProcessClientRequest(long numberOfClientRequest, Request rq)
        {
            switch (numberOfClientRequest)
            {
                case 1: RequestForCreateNewStorage(rq); break;
                case 2: RequestForCreateNewProduct(rq); break;
                case 3: RequestForGetAllStoragesInfo(); break;
                case 4: RequestForEnterInSpecificStorage(rq); break;
                case 5: RequestForGetStorageState(rq); break;
                case 6: RequestForGetProductInfo(rq); break;
                case 7: RequestForCheckIsProductExists(rq); break;
                case 8: RequestForProductsCostMin(rq); break;
                case 9: RequestForProductsCostMax(rq); break;
                case 10: RequestForProductsCostAvg(rq); break;
                case 11: RequestForProductsCostSum(rq); break;
                case 12: RequestForUpdateProduct(rq); break;
                case 13: RequestForDeleteProductFromStorage(rq); break;
            }
        }    

      

        private void RequestForGetAllStoragesInfo()
        {
            try
            {
                IStorageRepository storageRepository = new StorageRepository();
                IStorageService storageService = new StorageService(storageRepository);
                List<Storage>  storages = storageService.GetAll().ToList();


                string response = string.Empty;
                storages.ForEach(storage => 
                {
                    response += storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content + System.Environment.NewLine;
                });
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForEnterInSpecificStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IStorageRepository storageRepository = new StorageRepository();
                IStorageService storageService = new StorageService(storageRepository);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                Storage storage = storageService.Enter(nameOfStorage);


                string response = storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForGetStorageState(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string kindOfStorage = rq.Args[1];
                string discountContent = rq.Args[2];

                this.discount = new Discount
                {
                    Value = Convert.ToDouble(discountContent),
                    Percentage = new Percentage("%")
                };
                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IStorageItemService storageItemsService = new StorageItemService(storageItemRepository, this.discount);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                List<StorageItem> storageItems = storageItemsService.GetStateOfStorage(nameOfStorage).ToList();



                string response = string.Empty;
                storageItems.ForEach(storageItem =>
                {
                    response += storageItem.NameOfProduct.Content + " " + storageItem.CountOfProduct + System.Environment.NewLine;
                });
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }

        }

        private void RequestForCreateNewStorage(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageRepository storageRepository = new StorageRepository();
                IStorageService storageService = new StorageService(storageRepository);
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage(name),
                    KindOfStorage = new KindOfStorage(kind)
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForCreateNewProduct(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];
                string discountContent = rq.Args[4];


                IProductRepository productRepository = new ProductRepository();
                IProductService productService = new ProductService(productRepository);
                Product product = new Product
                {
                    NameOfProduct = new NameOfProduct(nameOfProduct),
                    Cost = new UnitCost
                    {
                        Value = Convert.ToDouble(unitCostString),
                        Currency = new Currency("EUR")
                    }                    
                };
                productService.Create(product);

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IStorageItemService storageItemService = new StorageItemService(storageItemRepository, this.discount);
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage(nameOfStorage),
                    NameOfProduct = new NameOfProduct(nameOfProduct),
                    CountOfProduct = Convert.ToInt32(countString)
                };
                storageItemService.Insert(storageItem);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForGetProductInfo(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];
                string discountContent = rq.Args[2];

                IProductRepository productRepository = new ProductRepository();
                IProductService productService = new ProductService(productRepository);
                NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
                Product product = productService.Get(nameOfProduct);

                this.discount = new Discount
                {
                    Value = Convert.ToDouble(discountContent),
                    Percentage = new Percentage("%")
                };
                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IStorageItemService storageItemService = new StorageItemService(storageItemRepository, this.discount);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                StorageItem storageItem = storageItemService.Get(nameOfStorage, product.NameOfProduct);


                string response = product.NameOfProduct.Content + " " + product.Cost.Value + " " + storageItem.CountOfProduct;
                writeResponse(response);

            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForCheckIsProductExists(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];
                string discountContent = rq.Args[2];

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IStorageItemService storageItemService = new StorageItemService(storageItemRepository, this.discount);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
                bool isExist = storageItemService.IsProductExistsInStorage(nameOfStorage, nameOfProduct);



                string response = string.Empty;
                if (isExist == true)
                {
                    response = "true";
                }
                else
                {
                    response = "false";
                }
                writeResponse(response);

            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }
       
        private void RequestForUpdateProduct(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];
                string kindOfStorage = rq.Args[4];
                string discountContent = rq.Args[5];


                IProductRepository productRepository = new ProductRepository();
                IProductService productService = new ProductService(productRepository);
                Product product = new Product
                {
                    NameOfProduct = new NameOfProduct(nameOfProduct),
                    Cost = new UnitCost
                    {
                        Value = Convert.ToDouble(unitCostString),
                        Currency = new Currency("EUR")
                    }
                };
                productService.Update(product);

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IStorageItemService storageItemService = new StorageItemService(storageItemRepository, this.discount);
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage(nameOfStorage),
                    NameOfProduct = new NameOfProduct(nameOfProduct),
                    CountOfProduct = Convert.ToInt32(countString)
                };
                storageItemService.Update(storageItem);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForDeleteProductFromStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string nameOfProductContent = rq.Args[1];
                string discountContent = rq.Args[2];

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IStorageItemService storageItemService = new StorageItemService(storageItemRepository, this.discount);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
                storageItemService.Delete(nameOfStorage, nameOfProduct);

            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForProductsCostMin(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string discountContent = rq.Args[1];

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IProductRepository productRepository = new ProductRepository();
                IMoneyItemValueService moneyItemValueService = new MoneyItemValueService(storageItemRepository, productRepository);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                MoneyItemValue moneyItem = moneyItemValueService.Min(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForProductsCostMax(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string discountContent = rq.Args[1];

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IProductRepository productRepository = new ProductRepository();
                IMoneyItemValueService moneyItemValueService = new MoneyItemValueService(storageItemRepository, productRepository);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                MoneyItemValue moneyItem = moneyItemValueService.Max(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForProductsCostAvg(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string discountContent = rq.Args[1];

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IProductRepository productRepository = new ProductRepository();
                IMoneyItemValueService moneyItemValueService = new MoneyItemValueService(storageItemRepository, productRepository);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                MoneyItemValue moneyItem = moneyItemValueService.Avg(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForProductsCostSum(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string discountContent = rq.Args[1];

                IStorageItemRepository storageItemRepository = new StorageItemRepository(this.discount);
                IProductRepository productRepository = new ProductRepository();
                IMoneyItemValueService moneyItemValueService = new MoneyItemValueService(storageItemRepository, productRepository);
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                MoneyItemValue moneyItem = moneyItemValueService.Sum(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }
     
        private void truncateRequestFile()
        {
            // Delete data from the Transaction.tmp file
            FileStream fs = new FileStream(pathForRequest, FileMode.Truncate);
            fs.Flush();
            fs.Close();
        }

        private void writeResponse(string response)
        {
            StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
            sw.WriteLine(response);
            sw.Flush();
            sw.Close();
            con.Close();
        }

        private void writeExceptionMessage(string message)
        {
            StreamWriter sw = new StreamWriter(new FileStream("C:\\DDDDemo\\ExceptionsFromService.db", FileMode.Append, FileAccess.Write));
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }


    }
}
