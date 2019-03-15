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
            string[] Requests = File.ReadAllLines(pathForRequest);
            foreach (string Request in Requests)
            {
                string[] RequestParts = Request.Split(' ');
                List<string> args = new List<string>();
                for (int i = 2; i < RequestParts.Length; i++)
                {
                    args.Add(RequestParts[i]);
                }
                Request rq = new Request(RequestParts[0], RequestParts[1], args);

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
                case 1: RequestForCreateNewStorage1(rq); break;
                case 2: RequestForCreateNewStorage2(rq); break;
                case 3: RequestForCreateNewStorage3(rq); break;
                case 4: RequestForCreateNewStorage4(rq); break;
                case 5: RequestForCreateNewStorage5(rq); break;
                case 6: RequestForCreateNewStorage6(rq); break;
                case 7: RequestForCreateNewStorage7(rq); break;
                case 8: RequestForCreateNewStorage8(rq); break;
                case 9: RequestForCreateNewStorage9(rq); break;
                case 10: RequestForCreateNewStorage10(rq); break;
                case 11: RequestForCreateNewProduct1(rq); break;
                case 12: RequestForCreateNewProduct2(rq); break;
                case 13: RequestForCreateNewProduct3(rq); break;
                case 14: RequestForCreateNewProduct4(rq); break;
                case 15: RequestForCreateNewProduct5(rq); break;
                case 16: RequestForCreateNewProduct6(rq); break;
                case 17: RequestForCreateNewProduct7(rq); break;
                case 18: RequestForCreateNewProduct8(rq); break;
                case 19: RequestForCreateNewProduct9(rq); break;
                case 20: RequestForCreateNewProduct10(rq); break;
                case 21: RequestForGetAllStoragesInfo(); break;
                case 23: RequestForEnterInSpecificStorage(rq); break;
                case 24: RequestForGetStorageState(rq); break;
                case 25: RequestForGetProductInfo(rq); break;
                case 26: RequestForCheckIsProductExists(rq); break;
                case 27: RequestForProductsCostMin1(rq); break;
                case 28: RequestForProductsCostMin2(rq); break;
                case 29: RequestForProductsCostMin3(rq); break;
                case 30: RequestForProductsCostMin4(rq); break;
                case 31: RequestForProductsCostMin5(rq); break;
                case 32: RequestForProductsCostMin6(rq); break;
                case 33: RequestForProductsCostMin7(rq); break;
                case 34: RequestForProductsCostMin8(rq); break;
                case 35: RequestForProductsCostMin9(rq); break;
                case 36: RequestForProductsCostMin10(rq); break;
                case 37: RequestForProductsCostMax(rq); break;
                case 38: RequestForProductsCostAvg(rq); break;
                case 39: RequestForProductsCostSum(rq); break;
                case 40: RequestForUpdateProduct(rq); break;
                case 41: RequestForDeleteProductFromStorage(rq); break;
                case 42: RequestForInsertNewTruck1(rq); break;
                case 43: RequestForInsertNewTruck2(rq); break;
                case 44: RequestForInsertNewTruck3(rq); break;
                case 45: RequestForInsertNewTruck4(rq); break;
                case 46: RequestForInsertNewTruck5(rq); break;
                case 47: RequestForInsertNewTruck6(rq); break;
                case 48: RequestForInsertNewTruck7(rq); break;
                case 49: RequestForInsertNewTruck8(rq); break;
                case 50: RequestForInsertNewTruck9(rq); break;
                case 51: RequestForInsertNewTruck10(rq); break;
                case 52: RequestForSendingTruck(rq); break;
                case 53: RequestForDeliveredProductsByTruck(rq); break;
            }*/

     
        }


    }
}
