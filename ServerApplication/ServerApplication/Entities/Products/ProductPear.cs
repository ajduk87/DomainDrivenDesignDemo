﻿using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.Entities.Products
{
    public class ProductPear : Entity
    {
        public NameOfProduct NameOfProduct { get; set; }
        public UnitCost Cost { get; set; }
    }
}
