using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.FactoryFolder
{
    public static class ProductFactory
    {
        public static Entity Create(EntityTypes entityType, string nameOfProductContent, string unitCostContent, string currency)
        {
            NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
            UnitCost cost = new UnitCost
            {
                Value = Convert.ToDouble(unitCostContent),
                Currency = new Currency("EUR")
            };


            switch (entityType)
            {
                case EntityTypes.ProductApple: { return new ProductApple(nameOfProduct, cost); }
                case EntityTypes.ProductBanana: { return new ProductBanana(nameOfProduct, cost); }
                case EntityTypes.ProductBlueberry: { return new ProductBlueberry(nameOfProduct, cost); }
                case EntityTypes.ProductCabbage: { return new ProductCabbage(nameOfProduct, cost); }
                case EntityTypes.ProductCherry: { return new ProductCherry(nameOfProduct, cost); }
                case EntityTypes.ProductGrape: { return new ProductGrape(nameOfProduct, cost); }
                case EntityTypes.ProductMandarin: { return new ProductMandarin(nameOfProduct, cost); }
                case EntityTypes.ProductMango: { return new ProductMango(nameOfProduct, cost); }
                case EntityTypes.ProductOrange: { return new ProductOrange(nameOfProduct, cost); }
                case EntityTypes.ProductPear: { return new ProductPear(nameOfProduct, cost); }
                case EntityTypes.ProductPlum: { return new ProductPlum(nameOfProduct, cost); }
                case EntityTypes.ProductRaspberry: { return new ProductRaspberry(nameOfProduct, cost); }
                case EntityTypes.ProductStrawberry: { return new ProductStrawberry(nameOfProduct, cost); }
                case EntityTypes.ProductTomato: { return new ProductTomato(nameOfProduct, cost); }
                case EntityTypes.ProductWaterMelon: { return new ProductWaterMelon(nameOfProduct, cost); }

                default: { return new ProductApple(nameOfProduct, cost); }
            }
        }
    }
}
