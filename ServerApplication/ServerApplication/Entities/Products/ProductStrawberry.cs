﻿using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductStrawberry : Entity
    {
        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }

        public ProductStrawberry(NameOfProduct nameOfProduct, UnitCost unitCost)
        {
            this.NameOfProduct = nameOfProduct;
            this.Cost = unitCost;
        }
    }
}
