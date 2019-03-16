﻿using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductGrape : Entity
    {
        public ProductGrape(NameOfProduct NameOfProduct, UnitCost Cost)
        {
            this.NameOfProduct = NameOfProduct;
            this.Cost = Cost;
        }

        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }
    }
}
