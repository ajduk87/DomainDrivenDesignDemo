using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ClientApplication.ControllerClasses
{
    public class Product
    {

        #region members

        private string _name = string.Empty;
        private int _count = 0;
        private double _cost = 0.0;        

        #endregion

        #region constructors

        public Product() 
        {
            _name = string.Empty;
            _count = 0;
            _cost = 0.0;
        }

        public Product(string name, double cost, int count)
        {
            _name = name;
            _count = count;
            _cost = cost;
        }

        #endregion

        #region properties

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public int Count
        {
            get { return _count; }
            set { _count = value; }
        }

        public double Cost
        {
            get { return _cost; }
            set { _cost = value; }
        }
     

        #endregion
    }
}
