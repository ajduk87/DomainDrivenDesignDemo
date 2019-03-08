using ServerApplication.Entities;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Repositories.Implementations
{
    public class StorageItemRepository : IStorageItemRepository
    {
        private OleDbConnection con;
        private string connectionString = string.Empty;

        public StorageItemRepository()
        {
            this.connectionString = ConnectionStrings.conn;
        }

        public void Insert(StorageItem storageItem)
        {
            string query= "INSERT INTO StateOfStorages(NameOfStorage,NameOfProduct,CountOfProduct) VALUES('" + storageItem.NameOfStorage + "','" + storageItem.NameOfProduct + "','" + storageItem.CountOfProduct + "')";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            con.Close();
        }
        public StorageItem SelectByNameOfStorageAndProduct(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct)
        {
            StorageItem storageItem = new StorageItem();
            string query = "SELECT CountOfProduct FROM StateOfStorages WHERE NameOfProduct = '" + nameOfProduct.Content + "' AND NameOfStorage = '" + nameOfStorage.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string count = string.Empty;
            if (dr.Read())
            {
                count = dr["CountOfProduct"].ToString();
            }
            con.Close();

            storageItem.NameOfStorage = nameOfStorage;
            storageItem.NameOfProduct =nameOfProduct;
            storageItem.CountOfProduct = Convert.ToInt32(count);

            return storageItem;
        }
        public void Update(StorageItem storageItem)
        {
            string query = "UPDATE StateOfStorages SET CountOfProduct = '" + storageItem.CountOfProduct + "' WHERE NameOfProduct = '" + storageItem.NameOfProduct + "' AND NameOfStorage = '" + storageItem.NameOfStorage + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            con.Close();
        }
        public void Delete(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct)
        {
            string query = "DELETE FROM StateOfStorages WHERE NameOfProduct='" + nameOfProduct.Content + "' AND NameOfStorage = '" + nameOfStorage.Content +"'";
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
        public IEnumerable<StorageItem> Select(NameOfStorage nameOfStorage)
        {
            List<StorageItem> storageItems = new List<StorageItem>();
            string query = "select NameOfProduct,CountOfProduct from StateOfStorages where NameOfStorage = '" + nameOfStorage.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string count = string.Empty;
            while (dr.Read())
            {
                count = dr["CountOfProduct"].ToString();
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage { Content = dr["NameOfStorage"].ToString() },
                    NameOfProduct = new NameOfProduct { Content = dr["NameOfProduct"].ToString() },
                    CountOfProduct = Convert.ToInt32(count)
                };
                storageItems.Add(storageItem);
            }
            con.Close();
            return storageItems;
        }       
    }
}
