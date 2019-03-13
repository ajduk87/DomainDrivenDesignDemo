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
                case 13: RequestForDeleteProduct(rq); break;
            }
        }    

      

        private void RequestForGetAllStoragesInfo()
        {
            string query = "SELECT NameOfStorage, KindOfStorage FROM Storages";
            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                while (dr.Read())
                {
                    response += dr["NameOfStorage"].ToString() + " " + dr["KindOfStorage"].ToString() + System.Environment.NewLine;
                }

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForEnterInSpecificStorage(Request rq)
        {
            string name = rq.Args[0];
            string query = "SELECT NameOfStorage, KindOfStorage FROM Storages WHERE NameOfStorage = '" + name + "'";
            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                if (dr.Read())
                {
                    response = dr["NameOfStorage"].ToString() + dr["KindOfStorage"].ToString();
                }

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForGetStorageState(Request rq)
        {
            string nameOfStorage = rq.Args[0];
            string kindOfStorage = rq.Args[1];

            string query = "SELECT NameOfProduct, CountOfProduct FROM StateOfStorages WHERE NameOfStorage = '" + nameOfStorage + "'";
            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                while (dr.Read())
                {
                    response += dr["NameOfProduct"].ToString() + " " + dr["CountOfProduct"].ToString() + System.Environment.NewLine;
                }

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }

        }

        private void RequestForCreateNewStorage(Request rq)
        {
            string name = rq.Args[0];
            string kind = rq.Args[1];

            //execute database storage
            string query = "INSERT INTO Storages(NameOfStorage,KindOfStorage) VALUES('" + name + "','" + kind + "')";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();               
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForCreateNewProduct(Request rq)
        {
            string nameOfProduct = rq.Args[0];
            string unitCostString = rq.Args[1];
            string countString = rq.Args[2];
            string nameOfStorage = rq.Args[3];
            string kindOfStorage = rq.Args[4];

            int count = 0;
            bool isN = int.TryParse(countString, out count);
            double unitCost = 0;

            isN = double.TryParse(unitCostString, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out unitCost);

            //execute database storage
            string query0 = "SELECT NameOfProduct FROM Products WHERE NameOfProduct = '" + nameOfProduct + "'";
            string query1 = "INSERT INTO Products(NameOfProduct,Cost) VALUES('" + nameOfProduct + "','" + unitCost + "')";
            string query2 = "INSERT INTO StateOfStorages(NameOfStorage,NameOfProduct,CountOfProduct) VALUES('" + nameOfStorage + "','" + nameOfProduct + "','" + count + "')";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query0, con);
                OleDbDataReader dr = com.ExecuteReader();
                if (dr.HasRows == false)
                {
                    com = new OleDbCommand(query1, con);
                    com.ExecuteNonQuery();
                }
                com = new OleDbCommand(query2, con);
                com.ExecuteNonQuery();
                con.Close();              
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForGetProductInfo(Request rq)
        {
            string nameOfProduct = rq.Args[0];
            string nameOfStorage = rq.Args[1];
            string query1 = "SELECT Cost FROM Products WHERE NameOfProduct = '" + nameOfProduct + "'";
            string query2 = "SELECT CountOfProduct FROM StateOfStorages WHERE NameOfProduct = '" + nameOfProduct + "' AND NameOfStorage = '" + nameOfStorage + "'";
            string cost = string.Empty;
            string count = string.Empty;

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query1, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                if (dr.Read())
                {
                    cost = dr["Cost"].ToString();
                }

                com = new OleDbCommand(query2, con);
                dr = com.ExecuteReader();

                if (dr.Read())
                {
                    count = dr["CountOfProduct"].ToString();
                }

                response = nameOfProduct + " " + cost + " " + count;

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForCheckIsProductExists(Request rq)
        {
            string nameOfProduct = rq.Args[0];
            string nameOfStorage = rq.Args[1];

            string query = "SELECT * FROM StateOfStorages WHERE NameOfProduct = '" + nameOfProduct + "' AND NameOfStorage = '" + nameOfStorage + "'";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                if (dr.HasRows)
                {
                    response = "True";
                }
                else
                {
                    response = "False";
                }

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }
       
        private void RequestForUpdateProduct(Request rq)
        {
            string nameOfProduct = rq.Args[0];
            string unitCostString = rq.Args[1];
            string countString = rq.Args[2];
            string nameOfStorage = rq.Args[3];
            string kindOfStorage = rq.Args[4];

            int count = 0;
            bool isN = int.TryParse(countString, out count);
            double unitCost = 0;

            isN = double.TryParse(unitCostString, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out unitCost);

            string query1 = "UPDATE Products SET Cost = '" + unitCost + "' WHERE NameOfProduct = '" + nameOfProduct + "'";
            string query2 = "UPDATE StateOfStorages SET CountOfProduct = '" + count + "' WHERE NameOfProduct = '" + nameOfProduct + "' AND NameOfStorage = '" + nameOfStorage + "'";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query1, con);
                com.ExecuteNonQuery();
                com = new OleDbCommand(query2, con);
                com.ExecuteNonQuery();
                con.Close();               
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForDeleteProduct(Request rq)
        {
            string nameOfProduct = rq.Args[0];
            string nameOfStorage = rq.Args[1];
            string kindOfStorage = rq.Args[2];
            string query = "DELETE FROM StateOfStorages WHERE NameOfProduct='" + nameOfProduct + "' ";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                com.ExecuteNonQuery();
                con.Close();
               
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);
            }
        }

        private void RequestForProductsCostMin(Request rq)
        {
            string nameOfStorage = rq.Args[0];

            string query = "select Products.NameOfProduct AS ProductName,Cost,CountOfProduct from Products,StateOfStorages where Products.NameOfProduct = StateOfStorages.NameOfProduct AND NameOfStorage = '" + nameOfStorage + "'";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                string nameOfProductTemp = string.Empty;
                double costTemp = 0.0;
                int countTemp = 0;
                double multipleTemp = 0.0;
                string currentNameOfProductMin = string.Empty;
                int currentCountMin = 0;
                double currentCostMin = 0.0;
                double currentMin = double.MaxValue;
                bool isN = false;
                while (dr.Read())
                {
                    nameOfProductTemp = dr["ProductName"].ToString();
                    string costLocal = dr["Cost"].ToString();
                    costLocal = costLocal.Replace(',', '.');
                    isN = double.TryParse(costLocal, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out costTemp);

                    isN = int.TryParse(dr["CountOfProduct"].ToString(), out countTemp);
                    multipleTemp = countTemp * costTemp;
                    if (multipleTemp < currentMin)
                    {
                        currentMin = countTemp * costTemp;
                        currentNameOfProductMin = nameOfProductTemp;
                        currentCostMin = costTemp;
                        currentCountMin = countTemp;
                    }
                }


                response = currentMin + " " + currentNameOfProductMin + " " + currentCostMin + " " + currentCountMin;

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForProductsCostMax(Request rq)
        {
            string nameOfStorage = rq.Args[0];

            string query = "select Products.NameOfProduct AS ProductName,Cost,CountOfProduct from Products,StateOfStorages where Products.NameOfProduct = StateOfStorages.NameOfProduct AND NameOfStorage = '" + nameOfStorage + "'";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                string nameOfProductTemp = string.Empty;
                double costTemp = 0.0;
                int countTemp = 0;
                double multipleTemp = 0.0;
                string currentNameOfProductMax = string.Empty;
                int currentCountMax = 0;
                double currentCostMax = 0.0;
                double currentMax = double.MinValue;
                bool isN = false;
                while (dr.Read())
                {
                    nameOfProductTemp = dr["ProductName"].ToString();
                    string costLocal = dr["Cost"].ToString();
                    costLocal = costLocal.Replace(',', '.');
                    isN = double.TryParse(costLocal, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out costTemp);

                    isN = int.TryParse(dr["CountOfProduct"].ToString(), out countTemp);
                    multipleTemp = countTemp * costTemp;
                    if (multipleTemp > currentMax)
                    {
                        currentMax = countTemp * costTemp;
                        currentNameOfProductMax = nameOfProductTemp;
                        currentCostMax = costTemp;
                        currentCountMax = countTemp;
                    }
                }


                response = currentMax + " " + currentNameOfProductMax + " " + currentCostMax + " " + currentCountMax;

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForProductsCostAvg(Request rq)
        {
            string nameOfStorage = rq.Args[0];

            string query = "select Products.NameOfProduct AS ProductName,Cost,CountOfProduct from Products,StateOfStorages where Products.NameOfProduct = StateOfStorages.NameOfProduct AND NameOfStorage = '" + nameOfStorage + "'";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                string nameOfProductTemp = string.Empty;
                double costTemp = 0.0;
                int countTemp = 0;
                double multipleTemp = 0.0;
                bool isN = false;
                int counter = 0;
                double sum = 0.0;
                while (dr.Read())
                {
                    nameOfProductTemp = dr["ProductName"].ToString();
                    string costLocal = dr["Cost"].ToString();
                    costLocal = costLocal.Replace(',', '.');
                    isN = double.TryParse(costLocal, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out costTemp);

                    isN = int.TryParse(dr["CountOfProduct"].ToString(), out countTemp);
                    multipleTemp = countTemp * costTemp;
                    sum += multipleTemp;
                    counter++;
                }

                double average = sum / counter;

                response = average.ToString();

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
            }
            catch (Exception ex)
            {
                writeExceptionMessage(ex.Message);

            }
        }

        private void RequestForProductsCostSum(Request rq)
        {
            string nameOfStorage = rq.Args[0];

            string query = "select Products.NameOfProduct AS ProductName,Cost,CountOfProduct from Products,StateOfStorages where Products.NameOfProduct = StateOfStorages.NameOfProduct AND NameOfStorage = '" + nameOfStorage + "'";

            try
            {
                con.Open();
                OleDbCommand com = new OleDbCommand(query, con);
                OleDbDataReader dr = com.ExecuteReader();
                string response = string.Empty;
                string nameOfProductTemp = string.Empty;
                double costTemp = 0.0;
                int countTemp = 0;
                double multipleTemp = 0.0;
                bool isN = false;
                double sum = 0.0;
                while (dr.Read())
                {
                    nameOfProductTemp = dr["ProductName"].ToString();
                    string costLocal = dr["Cost"].ToString();
                    costLocal = costLocal.Replace(',', '.');
                    isN = double.TryParse(costLocal, System.Globalization.NumberStyles.Any, CultureInfo.GetCultureInfo("en-US"), out costTemp);

                    isN = int.TryParse(dr["CountOfProduct"].ToString(), out countTemp);
                    multipleTemp = countTemp * costTemp;
                    sum += multipleTemp;
                }


                response = sum.ToString();

                StreamWriter sw = new StreamWriter(new FileStream(pathForResponse, FileMode.Append, FileAccess.Write));
                sw.WriteLine(response);
                sw.Flush();
                sw.Close();
                con.Close();
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

        private void writeExceptionMessage(string message)
        {
            StreamWriter sw = new StreamWriter(new FileStream("C:\\DDDDemo\\ExceptionsFromService.db", FileMode.Append, FileAccess.Write));
            sw.WriteLine(message);
            sw.Flush();
            sw.Close();
        }


    }
}
