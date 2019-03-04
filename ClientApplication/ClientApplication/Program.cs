using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ClientApplication.ControllerClasses;
using System.IO;
using System.ServiceProcess;
using System.Globalization;

namespace ClientApplication
{
    public class Program
    {
       public static bool IsTimeoutHappened = false;
       public static int Timeout = 500 * 60;//timeout for service response if client waits response is 30 seconds
       private static StorageManager storageManager;
       public static BufferAddress bufferAddress;
       public static string pathForRequest = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForRequest.txt";
       public static string pathForResponse = "C:\\DomainDrivenDesignDemo\\Buffers\\bufferForResponse.txt";

       private static void displayStorageMenu(Storage storageChosen) 
       {
           Console.WriteLine("Storage Menu for " + storageChosen.Name + " [" + storageChosen.Kind + "] :");
           Console.WriteLine("a. Insert new product");
           Console.WriteLine("b. Read existing product");
           Console.WriteLine("c. Update existing product");
           Console.WriteLine("d. Delete existing product");
           Console.WriteLine("e. Get min cost of products");
           Console.WriteLine("f. Get max cost of products");
           Console.WriteLine("g. Get average cost of products");
           Console.WriteLine("h. Get sum cost of all products");
           Console.WriteLine("j. Display state of current storage");
           Console.WriteLine("i. Exit from storage " + storageChosen.Name + " [" + storageChosen.Kind + "]");
       }


        public static void Main(string[] args)
        {

            Console.WriteLine("Loading storages info ...");
            storageManager = StorageManager.Instance;
            //initialize with storages
            storageManager.SendRequestForExistingStorages();
            List<string> storages = storageManager.gettingStorages();
            foreach (string item in storages)
            {
                string name = string.Empty;
                string kind = string.Empty;
                List<string> storageParts = item.Split(' ').ToList();
                if (storageParts.Count == 2)
                {
                    name = storageParts[0];
                    kind = storageParts[1];
                    storageManager[name + kind] = new Storage(name, kind);
                }
            }

            
            bufferAddress = BufferAddress.GetInstance(pathForRequest,pathForResponse);

            bool isUserWantsToWork = true;
            bool isFirstTime = true;
            

            while (isUserWantsToWork)
            {
                ConsoleKeyInfo choice = new ConsoleKeyInfo();
                if (isFirstTime == false)
                {
                    Console.WriteLine(System.Environment.NewLine + "Do you want to continue ? (Press Y or y if you want otherwise press any key different from Y or y)");
                    choice = Console.ReadKey();
                }

                if (choice.KeyChar == 'Y' || choice.KeyChar == 'y' || isFirstTime == true)
                {                  
                    
                    if (isFirstTime == true)
                    {
                        Console.WriteLine("User Menu :");
                        Console.WriteLine("1. Insert new storage");
                        Console.WriteLine("2. Enter in exisitng storage");
                        Console.WriteLine("3. Show exisitng storages");
                        isFirstTime = false;
                    }
                    else
                    {
                        Console.WriteLine(System.Environment.NewLine + "User Menu :");
                        Console.WriteLine("1. Insert new storage");
                        Console.WriteLine("2. Enter in exisitng storage");
                        Console.WriteLine("3. Show exisitng storages");
                    }

                    choice = Console.ReadKey();


                    if (choice.KeyChar == '1')
                    {
                        Console.WriteLine(System.Environment.NewLine + "Enter name of storage : ");
                        string name = Console.ReadLine();
                        Console.WriteLine("Kind of storage (for example Fruits,Vegetables) : ");
                        string kind = Console.ReadLine();

                        storageManager[name + kind] = new Storage(name, kind);
                        if (File.Exists(bufferAddress.PathForRequestBuff) == false)
                        {
                            File.Create(bufferAddress.PathForRequestBuff);                                
                        }
                        string request = "INSERT STORAGE " + name + " " + kind;
                        List<string> listOfRequests = new List<string>();
                        listOfRequests.Add(request);
                        File.AppendAllLines(bufferAddress.PathForRequestBuff, listOfRequests);

                        ServiceController sc = new ServiceController("DDDDemoServerService");
                        sc.ExecuteCommand(200);
                            

                    }
                    if (choice.KeyChar == '2')
                    {

                        Console.WriteLine(System.Environment.NewLine + "Enter name of Storage: ");
                        string name = Console.ReadLine();
                        string key = string.Empty;
                        storageManager.SendRequestForStorageKey(name);
                        key = storageManager.GetStorageKey();
                        Storage storageChosen = storageManager[key].Clone() as Storage;
                        
                       
                        
                        Console.WriteLine("You are now in storage " + storageChosen.Name + " [" + storageChosen.Kind + "]" + System.Environment.NewLine);

                        //this is menu when you are in some storage

                        displayStorageMenu(storageChosen);
                        choice = Console.ReadKey();
                        while (choice.KeyChar != 'i' && choice.KeyChar != 'I')
                        {
                            //izvrsi uneti zahtev
                            if (choice.KeyChar == 'a' || choice.KeyChar == 'A')
                            {
                                Console.WriteLine(System.Environment.NewLine + "Enter name of new Product: ");
                                string nameOfProduct = Console.ReadLine();
                                Console.WriteLine("Enter unit cost of Product " + nameOfProduct +": ");
                                string unitCostString = Console.ReadLine();
                                Console.WriteLine("Enter count of Product " + nameOfProduct + ": ");
                                string countString = Console.ReadLine();
                                double unitCost = 0;
                                bool isNUnitCost = double.TryParse(unitCostString, out unitCost);
                                if (isNUnitCost == false) 
                                {
                                    Console.WriteLine("Unit cost of Product must be number !!!");
                                }
                                int count = 0;
                                bool isNCount = int.TryParse(countString, out count);
                                if (isNCount == false)
                                {
                                    Console.WriteLine("Count of Product must be number !!!");
                                }
                                if (isNUnitCost == true && isNCount == true)
                                {
                                    bool isProductAlreadyExist = false;
                                    Product newProduct = new Product(nameOfProduct, unitCost, count);
                                    Console.WriteLine("Checking for product existance...");
                                    storageChosen.SendRequestForProductCheck(newProduct.Name);
                                    isProductAlreadyExist = storageChosen.GetResponseForProductCheck();
                                    if (isProductAlreadyExist == false)
                                    {
                                        storageChosen.SendRequestForAddedNewProduct(newProduct);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Product with name " + newProduct.Name + " already exist in current storage !!!");
                                    }
                                }
                            }

                            if (choice.KeyChar == 'b' || choice.KeyChar == 'B')
                            {
                                Console.WriteLine(System.Environment.NewLine + "Enter name of existing Product: ");
                                string nameOfProduct = Console.ReadLine();
                                Console.WriteLine(System.Environment.NewLine + "Waiting for product info...");
                                storageChosen.SendRequestForProductInfo(nameOfProduct);
                                Product productChosen = storageChosen.GetProductInfo();
                                if (productChosen.Name.Equals(string.Empty) == false)
                                {
                                    Console.WriteLine(System.Environment.NewLine + "Name : " + productChosen.Name);
                                    Console.WriteLine("Cost of unit : " + productChosen.Cost);
                                    Console.WriteLine("Count : " + productChosen.Count);
                                }
                                else
                                {
                                    Console.WriteLine(System.Environment.NewLine + "Product with name " + nameOfProduct + " doesn't exist in this storage !!!");
                                }
                            }

                            if (choice.KeyChar == 'c' || choice.KeyChar == 'C')
                            {
                                Console.WriteLine(System.Environment.NewLine + "Enter name of updating Product: ");
                                string nameOfProduct = Console.ReadLine();
                                Console.WriteLine("Enter new cost of Product with name " + nameOfProduct +" : ");
                                string costOfProductString = Console.ReadLine();
                                Console.WriteLine("Enter new count of Product with name " + nameOfProduct + " : ");
                                string countOfProductString = Console.ReadLine();
                                double costOfProduct = 0.0;
                                bool isNUnitCost = double.TryParse(costOfProductString,System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out costOfProduct);
                                int countOfProduct = 0;
                                bool isNCount = int.TryParse(countOfProductString, out countOfProduct);
                                if (isNUnitCost == true && isNCount == true)
                                {
                                    Product updateProduct = new Product(nameOfProduct, costOfProduct, countOfProduct);
                                    
                                    storageChosen.SendRequestForUpdateProduct(updateProduct);
                                }
                            }


                            if (choice.KeyChar == 'd' || choice.KeyChar == 'D')
                            {
                                Console.WriteLine(System.Environment.NewLine + "Enter name of deleting Product: ");
                                string nameOfProduct = Console.ReadLine();
                                
                                storageChosen.SendRequestForDeleteProduct(nameOfProduct);
                            }

                            if (choice.KeyChar == 'e' || choice.KeyChar == 'E')
                            {
                                double min = 0;
                                Console.WriteLine(System.Environment.NewLine + "Waiting for min cost of this storage...");
                                storageChosen.SendRequestForProductsCostMin();
                                Product productMin = storageChosen.GetResponseForProductsCostMin(out min);
                                
                                Console.WriteLine(System.Environment.NewLine + "Min for this storage is : " + min);
                                Console.WriteLine("Name of product is : " + productMin.Name);
                                Console.WriteLine("Unit cost of product is : " + productMin.Cost);
                                Console.WriteLine("Count of product is : " + productMin.Count);
                              
                            }

                            if (choice.KeyChar == 'f' || choice.KeyChar == 'F')
                            {
                                double max = 0;
                                Console.WriteLine(System.Environment.NewLine + "Waiting for max cost of this storage...");
                                storageChosen.SendRequestForProductsCostMax();
                                Product productMax = storageChosen.GetResponseForProductsCostMax(out max);
                                
                                Console.WriteLine(System.Environment.NewLine + "Max for this storage is : " + max);
                                Console.WriteLine("Name of product is : " + productMax.Name);
                                Console.WriteLine("Unit cost of product is : " + productMax.Cost);
                                Console.WriteLine("Count of product is : " + productMax.Count);
                                
                            }

                            if (choice.KeyChar == 'g' || choice.KeyChar == 'G')
                            {
                                double average = 0.0;
                                Console.WriteLine(System.Environment.NewLine + "Waiting for average cost of this storage...");
                                storageChosen.SendRequestForProductsCostAvg();
                                average = storageChosen.GetResponseForProductsCostAvg();                                
                                Console.WriteLine(System.Environment.NewLine + "Average cost for this storage is : " + average);                                
                            }

                            if (choice.KeyChar == 'h' || choice.KeyChar == 'H')
                            {
                                double sum = 0.0;
                                Console.WriteLine(System.Environment.NewLine + "Waiting for sum cost of this storage...");
                                storageChosen.SendRequestForProductsCostSum();
                                sum = storageChosen.GetResponseForProductsCostSum();  
                                Console.WriteLine(System.Environment.NewLine + "Sum cost for this storage is : " + sum); 
                            }

                            if (choice.KeyChar == 'j' || choice.KeyChar == 'J')
                            {
                                Console.WriteLine(System.Environment.NewLine + "Loading Data in progress..." + System.Environment.NewLine);
                                /***ovde moras traziti zahtev da se pokupi trenutno stanje u trazenom magacinu BEGIN***/
                                storageChosen.SendRequestForState();
                                storageChosen.GetStorageItems();                               
                                /***ovde moras traziti zahtev da se pokupi trenutno stanje u trazenom magacinu END***/

                                Console.WriteLine();
                                foreach (StorageItem storageItem in storageChosen.StorageItems)
                                {
                                    Console.WriteLine(storageItem.NameOfProduct + " " + storageItem.CountOfProduct);
                                }
                            }


                            Console.WriteLine(System.Environment.NewLine + "Request is processed sucessfully for  " + choice.KeyChar);

                            displayStorageMenu(storageChosen);
                            choice = Console.ReadKey();
                        }
                    }
                    if (choice.KeyChar == '3')
                    {
                        storageManager.SendRequestForExistingStorages();
                        storages = storageManager.gettingStorages();
                        foreach (string item in storages)
                        {
                            string name = string.Empty;
                            string kind = string.Empty;
                            List<string> storageParts = item.Split(' ').ToList();
                            if (storageParts.Count == 2)
                            {
                                name = storageParts[0];
                                kind = storageParts[1];
                                storageManager[name + kind] = new Storage(name, kind);
                            }
                        }

                        Console.WriteLine(System.Environment.NewLine + "Name" + " " + "Kind" + System.Environment.NewLine);
                        foreach (var storagePrototype in storageManager.StorageInSystem)
                        {
                            Storage storage = storagePrototype.Value.Clone() as Storage;

                            Console.WriteLine(storage.Name + " " + storage.Kind);
                        }
                    }
                    
                }
                else
                {
                    isUserWantsToWork = false;
                }
            }

        }
    }
}
