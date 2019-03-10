using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.FactoryFolder;
using ServerApplication.Repositories.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Repositories.Implementations.Products
{
    public class ProductAppleRepository : IProductAppleRepository
    {
        private OleDbConnection con;
        private string connectionString = string.Empty;

        public ProductAppleRepository()
        {
            this.connectionString = ConnectionStrings.conn;
        }

        public void Insert(ProductApple product)
        {
            OleDbConnection con = new OleDbConnection(this.connectionString);

            string query = "INSERT INTO Products(NameOfProduct,Cost) VALUES('" + product.NameOfProduct + "','" + product.Cost + "')";

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public ProductApple SelectByName(NameOfProduct name)
        {
            ProductApple product = (ProductApple)EntityFactory.Create(EntityTypes.ProductApple);

            OleDbConnection con = new OleDbConnection(this.connectionString);

            string query1 = "SELECT Cost FROM Products WHERE NameOfProduct = '" + name.Content + "'";

            con.Open();
            OleDbCommand com = new OleDbCommand(query1, con);
            OleDbDataReader dr = com.ExecuteReader();
            string cost = string.Empty;

            if (dr.Read())
            {
                cost = dr["Cost"].ToString();
            }

            con.Close();
            product.NameOfProduct = name;
            product.Cost = new UnitCost { Value = Convert.ToDouble(cost), Currency = new Currency { Content = "eur" } };

            return product;
        }

        public void Update(ProductApple product)
        {
            string query = "UPDATE Products SET Cost = '" + product.Cost + "' WHERE NameOfProduct = '" + product.NameOfProduct + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void Delete(NameOfProduct name)
        {
            string query = "DELETE FROM StateOfStorages WHERE NameOfProduct='" + name.Content + "' ";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }
    }
}
