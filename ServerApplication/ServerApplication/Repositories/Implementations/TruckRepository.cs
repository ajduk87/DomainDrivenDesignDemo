using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Repositories.Implementations
{
    public class TruckRepository : ITruckRepository
    {
        private OleDbConnection con;
        private string connectionString = string.Empty;

        public TruckRepository()
        {
            this.connectionString = ConnectionStrings.conn;
        }

        public void Insert(Truck truck)
        {
            OleDbConnection con = new OleDbConnection(this.connectionString);

            string query = "INSERT INTO Truck(TrailerId,WheelsId,EngineId,StatusId) VALUES('" + truck.Trailer.Id.Content + "','" + truck.Wheels.Id.Content + "'" + "','" + truck.Engine.Id.Content + "'" + "','" + TruckStatus.Available + "')";

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            com.ExecuteNonQuery();
            con.Close();
        }

        public void UpdateStatus(TruckId truckId, TruckStatus truckStatus)
        {
            string query = "UPDATE Truck SET StatusId = '" + (int)truckStatus + "' WHERE NameOfProduct = '" + truckId.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);
            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            con.Close();
        }

        public Trailer SelectTrailerByTrailerId(TrailerId trailerId)
        {
            Trailer trailer = new Trailer { Id = trailerId };
            string query = "SELECT Id, Capacity FROM Trailer WHERE Id = '" + trailerId.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string response = string.Empty;
            if (dr.Read())
            {
                trailer.Capacity = new TrailerCapacity
                {
                    Value = Convert.ToDouble(dr["Capacity"].ToString()),
                    WeightUnit = new WeightUnit
                    {
                        Content = "kg"
                    }
                };
            }
;
            con.Close();

            return trailer;
        }

        public Wheels SelectWheelsByWheelsId(WheelsId wheelsId)
        {
            Wheels wheels = new Wheels { Id = wheelsId };
            string query = "SELECT Size FROM Wheels WHERE Id = '" + wheelsId.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string response = string.Empty;
            if (dr.Read())
            {
                wheels.Size = new WheelsSize
                {
                    Value = Convert.ToInt32(dr["Size"].ToString()),
                    LengthUnit = new LengthUnit
                    {
                        Content = "cm"
                    }
                };
            }
;
            con.Close();

            return wheels;
        }

        public Engine SelectEnginesByEngineId(EngineId engineId)
        {
            Engine engine = new Engine { Id = engineId };
            string query = "SELECT Power FROM Engine WHERE Id = '" + engineId.Content + "'";
            OleDbConnection con = new OleDbConnection(this.connectionString);

            con.Open();
            OleDbCommand com = new OleDbCommand(query, con);
            OleDbDataReader dr = com.ExecuteReader();
            string response = string.Empty;
            if (dr.Read())
            {
                engine.Power = new EnginePower
                {
                    Value = Convert.ToInt32(dr["Power"].ToString()),
                    PowerUnit = new PowerUnit
                    {
                        Content = "W"
                    }
                };
            }
;
            con.Close();

            return engine;
        }
    }
}
