using ServerApplication.Entities;
using ServerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Repositories.Implementations
{
    public class StorageRepository : IStorageRepository
    {
        private string connectionString = string.Empty;

        public StorageRepository()
        {
            this.connectionString = ConnectionStrings.conn;
        }

        public void Insert(Storage storage)
        {
            OleDbConnection con = new OleDbConnection(this.connectionString);

            string query = "INSERT INTO Storages(NameOfStorage,KindOfStorage) VALUES('" + storage.NameOfStorage + "','" + storage.KindOfStorage + "')";

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
        public IEnumerable<Storage> SelectAll()
        {
            List<Storage> storages = new List<Storage>();
            OleDbConnection con = new OleDbConnection(this.connectionString);

            string query = "SELECT NameOfStorage, KindOfStorage FROM Storages";
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string response = string.Empty;
            while (dr.Read())
            {
                Storage storage = new Storage
                {
                    NameOfStorage = new NameOfStorage(dr["NameOfStorage"].ToString()),
                    KindOfStorage = new KindOfStorage(dr["KindOfStorage"].ToString())

                };
                storages.Add(storage);
            }

            con.Close();
            return storages;
        }
        public Storage SelectByName(NameOfStorage name)
        {
            Storage storage = new Storage();
            string query = "SELECT NameOfStorage, KindOfStorage FROM Storages WHERE NameOfStorage = '" + name.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string response = string.Empty;
            if (dr.Read())
            {
                storage.NameOfStorage = new NameOfStorage(dr["NameOfStorage"].ToString());
                storage.KindOfStorage = new KindOfStorage(dr["KindOfStorage"].ToString());
            }
;
            con.Close();

            return storage;
        }
    }
}
