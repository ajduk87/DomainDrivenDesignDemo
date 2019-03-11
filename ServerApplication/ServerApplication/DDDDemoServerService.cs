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
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Entities.Truck;
using ServerApplication.Commands.Callers;
using ServerApplication.Commands;
using ServerApplication.Modules.Commands;

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

        private CommmandStorageCaller commmandStorageCaller;
        private CommandTruckCaller commandTruckCaller;
        private CommandStorageItemCaller commandProductCaller;
        private CommandMoneyValueCaller commandMoneyValueCaller;

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

            objContainer.RegisterModule<CommandStorageModule>();
            objContainer.RegisterModule<CommandTruckModule>();
            objContainer.RegisterModule<CommandStorageItemModule>();
            objContainer.RegisterModule<CommandMoneyValueModule>();

            container = objContainer.Build();

            commmandStorageCaller = new CommmandStorageCaller(container);
            commandTruckCaller = new CommandTruckCaller(container);
            commandProductCaller = new CommandStorageItemCaller(container);
            commandMoneyValueCaller = new CommandMoneyValueCaller(container);
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
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Storage);
                        }

                    }//if (rq.Noun.Equals("STORAGE"))

                    if (rq.Noun.Equals("PRODUCT"))
                    {
                        if (rq.Args.Count == 5)
                        {
                            this.numberOfClientRequest = 2;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Storage);                            
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
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Storage);                            
                        }//end if (rq.Args.Count == 0)
                        if (rq.Args.Count == 1)
                        {
                            this.numberOfClientRequest = 4;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Storage);
                        }//end if (rq.Args.Count == 1)
                        if (rq.Args.Count == 2)
                        {
                            this.numberOfClientRequest = 5;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Storage);                            
                        }//end if (rq.Args.Count == 2)
                    }//if (rq.Noun.Equals("STORAGE"))

                    if (rq.Noun.Equals("PRODUCT"))
                    {
                        if (rq.Args.Count == 2)
                        {
                            this.numberOfClientRequest = 6;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Product);                            
                        }//if (rq.Args.Count == 2)

                        if (rq.Args.Count == 3 && rq.Args[2].Equals("CHECK"))
                        {
                            this.numberOfClientRequest = 7;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Product);                            
                        }//if (rq.Args.Count == 3)
                    }//if (rq.Noun.Equals("PRODUCT"))

                    if (rq.Noun.Equals("PRODUCTCOSTS"))
                    {
                        if (rq.Args.Count == 2 && rq.Args[1].Equals("MIN"))
                        {
                            this.numberOfClientRequest = 8;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.MoneyValue);                           

                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("MIN"))

                        if (rq.Args.Count == 2 && rq.Args[1].Equals("MAX"))
                        {
                            this.numberOfClientRequest = 9;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.MoneyValue);                            
                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("MAX"))

                        if (rq.Args.Count == 2 && rq.Args[1].Equals("AVG"))
                        {
                            this.numberOfClientRequest = 10;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.MoneyValue);
                            
                        }//if (rq.Args.Count == 2 && rq.Args[1].Equals("AVG"))

                        if (rq.Args.Count == 2 && rq.Args[1].Equals("SUM"))
                        {
                            this.numberOfClientRequest = 11;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.MoneyValue);
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
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Product);                           
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
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Product);                           
                        }//if (rq.Args.Count == 3)
                    }//if (rq.Noun.Equals("PRODUCT"))
                }//if (rq.Verb.Equals("DELETE")) 

                if (rq.Verb.Equals("INSERT"))
                {
                    if (rq.Noun.Equals("TRUCK"))
                    {
                        if (rq.Args.Count == 3)
                        {
                            this.numberOfClientRequest = 14;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Truck);
                        }
                    }
                }

                if (rq.Verb.Equals("PUT"))
                {
                    if (rq.Noun.Equals("TRUCK"))
                    {
                        if (rq.Args.Count == 1)
                        {
                            this.numberOfClientRequest = 14;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Truck);
                        }
                    }
                }

                if (rq.Verb.Equals("PUT"))
                {
                    if (rq.Noun.Equals("TRUCK"))
                    {
                        if (rq.Args.Count == 2)
                        {
                            this.numberOfClientRequest = 14;
                            ProcessClientRequest(this.numberOfClientRequest, rq, CommandTypes.Truck);
                        }
                    }
                }

            }
            truncateRequestFile();
        }

        private void ProcessClientRequest(long numberOfClientRequest, Request rq, CommandTypes commandType)
        {
            switch (commandType)
            {
                case CommandTypes.Storage: commmandStorageCaller.HandleRequest(numberOfClientRequest, rq);break;
                case CommandTypes.Product: commandProductCaller.HandleRequest(numberOfClientRequest, rq); break;
                case CommandTypes.MoneyValue: commandMoneyValueCaller.HandleRequest(numberOfClientRequest, rq); break;
                case CommandTypes.Truck: commandTruckCaller.HandleRequest(numberOfClientRequest, rq); break;

            }


            /*switch (numberOfClientRequest)
            {
                case 1: requestForCreateNewStorage1(rq); break;
                case 2: requestForCreateNewStorage2(rq); break;
                case 3: requestForCreateNewStorage3(rq); break;
                case 4: requestForCreateNewStorage4(rq); break;
                case 5: requestForCreateNewStorage5(rq); break;
                case 6: requestForCreateNewStorage6(rq); break;
                case 7: requestForCreateNewStorage7(rq); break;
                case 8: requestForCreateNewStorage8(rq); break;
                case 9: requestForCreateNewStorage9(rq); break;
                case 10: requestForCreateNewStorage10(rq); break;
                case 11: requestForCreateNewProduct1(rq); break;
                case 12: requestForCreateNewProduct2(rq); break;
                case 13: requestForCreateNewProduct3(rq); break;
                case 14: requestForCreateNewProduct4(rq); break;
                case 15: requestForCreateNewProduct5(rq); break;
                case 16: requestForCreateNewProduct6(rq); break;
                case 17: requestForCreateNewProduct7(rq); break;
                case 18: requestForCreateNewProduct8(rq); break;
                case 19: requestForCreateNewProduct9(rq); break;
                case 20: requestForCreateNewProduct10(rq); break;
                case 21: requestForGetAllStoragesInfo(); break;
                case 23: requestForEnterInSpecificStorage(rq); break;
                case 24: requestForGetStorageState(rq); break;
                case 25: requestForGetProductInfo(rq); break;
                case 26: requestForCheckIsProductExists(rq); break;
                case 27: requestForProductsCostMin1(rq); break;
                case 28: requestForProductsCostMin2(rq); break;
                case 29: requestForProductsCostMin3(rq); break;
                case 30: requestForProductsCostMin4(rq); break;
                case 31: requestForProductsCostMin5(rq); break;
                case 32: requestForProductsCostMin6(rq); break;
                case 33: requestForProductsCostMin7(rq); break;
                case 34: requestForProductsCostMin8(rq); break;
                case 35: requestForProductsCostMin9(rq); break;
                case 36: requestForProductsCostMin10(rq); break;
                case 37: requestForProductsCostMax(rq); break;
                case 38: requestForProductsCostAvg(rq); break;
                case 39: requestForProductsCostSum(rq); break;
                case 40: requestForUpdateProduct(rq); break;
                case 41: requestForDeleteProductFromStorage(rq); break;
                case 42: requestForInsertNewTruck1(rq); break;
                case 43: requestForInsertNewTruck2(rq); break;
                case 44: requestForInsertNewTruck3(rq); break;
                case 45: requestForInsertNewTruck4(rq); break;
                case 46: requestForInsertNewTruck5(rq); break;
                case 47: requestForInsertNewTruck6(rq); break;
                case 48: requestForInsertNewTruck7(rq); break;
                case 49: requestForInsertNewTruck8(rq); break;
                case 50: requestForInsertNewTruck9(rq); break;
                case 51: requestForInsertNewTruck10(rq); break;
                case 52: requestForSendingTruck(rq); break;
                case 53: requestForDeliveredProductsByTruck(rq); break;
            }*/
        }    

        private void truncateRequestFile()
        {
            // Delete data from the Transaction.tmp file
            FileStream fs = new FileStream(pathForRequest, FileMode.Truncate);
            fs.Flush();
            fs.Close();
        }


    }
}
