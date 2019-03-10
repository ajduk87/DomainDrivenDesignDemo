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
using Autofac;
using ServerApplication.Modules;
using ServerApplication.Entities.Products;
using ServerApplication.FactoryFolder;

namespace ServerApplication
{
    public partial class DDDDemoServerService : ServiceBase
    {
        private string pathForRequest = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForRequest.txt";
        private string pathForResponse = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForResponse.txt";
        private static string pathForDatabase = "C:\\DomainDrivenDesignDemo\\InfrastructureLayer\\Database\\Storages.accdb";
        private OleDbConnection con;
        private FileStream fs;
        private long numberOfClientRequest = 0;
        private ContainerBuilder objContainer;
        private Autofac.IContainer container;



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

            objContainer = new ContainerBuilder();

            //Registering Modules
            objContainer.RegisterModule<StoragesModule>();
            objContainer.RegisterModule<ProductsModule>();
            objContainer.RegisterModule<StorageItemModule>();
            objContainer.RegisterModule<MoneyItemValueModule>();

            container = objContainer.Build();
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
                case 1: requestForCreateNewStorage(rq); break;
                case 2: requestForCreateNewProduct(rq); break;
                case 3: requestForGetAllStoragesInfo(); break;
                case 4: requestForEnterInSpecificStorage(rq); break;
                case 5: requestForGetStorageState(rq); break;
                case 6: requestForGetProductInfo(rq); break;
                case 7: requestForCheckIsProductExists(rq); break;
                case 8: requestForProductsCostMin(rq); break;
                case 9: requestForProductsCostMax(rq); break;
                case 10: requestForProductsCostAvg(rq); break;
                case 11: requestForProductsCostSum(rq); break;
                case 12: requestForUpdateProduct(rq); break;
                case 13: requestForDeleteProductFromStorage(rq); break;
            }
        }    

      

        private void requestForGetAllStoragesInfo()
        {
            try
            {
                IStorageService storageService = container.Resolve<IStorageService>();
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

        private void requestForEnterInSpecificStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IStorageService storageService = container.Resolve<IStorageService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                Storage storage = storageService.Enter(nameOfStorage);


                string response = storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void requestForGetStorageState(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string kindOfStorage = rq.Args[1];

                IStorageItemService storageItemsService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
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

        private void requestForCreateNewStorage(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void requestForCreateNewProduct(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];


                IProductService productService = container.Resolve<IProductService>();
                ProductApple product = (ProductApple)EntityFactory.Create(EntityTypes.ProductApple);
                product.NameOfProduct = new NameOfProduct { Content = nameOfProduct };
                product.Cost = new UnitCost
                {
                    Value = Convert.ToDouble(unitCostString),
                    Currency = new Currency { Content = "EUR" }
                };
                  
                productService.Create(product);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage { Content = nameOfStorage },
                    NameOfProduct = new NameOfProduct { Content = nameOfProduct },
                    CountOfProduct = Convert.ToInt32(countString)
                };
                storageItemService.Insert(storageItem);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void requestForGetProductInfo(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];

                IProductService productService = container.Resolve<IProductService>();
                NameOfProduct nameOfProduct = new NameOfProduct { Content = nameOfProductContent };
                ProductApple product = productService.Get(nameOfProduct);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                StorageItem storageItem = storageItemService.Get(nameOfStorage, product.NameOfProduct);


                string response = product.NameOfProduct.Content + " " + product.Cost.Value + " " + storageItem.CountOfProduct;
                writeResponse(response);

            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void requestForCheckIsProductExists(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                NameOfProduct nameOfProduct = new NameOfProduct { Content = nameOfProductContent };
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
       
        private void requestForUpdateProduct(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];
                string kindOfStorage = rq.Args[4];


                IProductService productService = container.Resolve<IProductService>();
                ProductApple product = (ProductApple)EntityFactory.Create(EntityTypes.ProductApple);
                product.NameOfProduct = new NameOfProduct { Content = nameOfProduct };
                product.Cost = new UnitCost
                {
                    Value = Convert.ToDouble(unitCostString),
                    Currency = new Currency { Content = "EUR" }
                };
                productService.Update(product);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage { Content = nameOfStorage },
                    NameOfProduct = new NameOfProduct { Content = nameOfProduct },
                    CountOfProduct = Convert.ToInt32(countString)
                };
                storageItemService.Update(storageItem);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void requestForDeleteProductFromStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string nameOfProductContent = rq.Args[1];

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                NameOfProduct nameOfProduct = new NameOfProduct { Content = nameOfProductContent };
                storageItemService.Delete(nameOfStorage, nameOfProduct);

            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void requestForProductsCostMin(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IMoneyItemValueService moneyItemValueService = container.Resolve<IMoneyItemValueService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                MoneyItemValue moneyItem = moneyItemValueService.Min(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void requestForProductsCostMax(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IMoneyItemValueService moneyItemValueService = container.Resolve<IMoneyItemValueService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                MoneyItemValue moneyItem = moneyItemValueService.Max(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void requestForProductsCostAvg(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IMoneyItemValueService moneyItemValueService = container.Resolve<IMoneyItemValueService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                MoneyItemValue moneyItem = moneyItemValueService.Avg(nameOfStorage);



                string response = moneyItem.Value + " " + moneyItem.Currency.Content;
                writeResponse(response);
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void requestForProductsCostSum(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IMoneyItemValueService moneyItemValueService = container.Resolve<IMoneyItemValueService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
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
