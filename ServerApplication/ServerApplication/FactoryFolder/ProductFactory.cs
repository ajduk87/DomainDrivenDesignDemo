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
        public static Entity Create(EntityTypes entityType, NameOfProduct NameOfProduct, UnitCost Cost)
        {
            switch (entityType)
            {
                case EntityTypes.ProductApple: { return new ProductApple(NameOfProduct, Cost); }
                case EntityTypes.ProductBanana: { return new ProductBanana(NameOfProduct, Cost); }
                case EntityTypes.ProductBlueberry: { return new ProductBlueberry(NameOfProduct, Cost); }
                case EntityTypes.ProductCabbage: { return new ProductCabbage(NameOfProduct, Cost); }
                case EntityTypes.ProductCherry: { return new ProductCherry(NameOfProduct, Cost); }
                case EntityTypes.ProductGrape: { return new ProductGrape(NameOfProduct, Cost); }
                case EntityTypes.ProductMandarin: { return new ProductMandarin(NameOfProduct, Cost); }
                case EntityTypes.ProductMango: { return new ProductMango(NameOfProduct, Cost); }
                case EntityTypes.ProductOrange: { return new ProductOrange(NameOfProduct, Cost); }
                case EntityTypes.ProductPear: { return new ProductPear(NameOfProduct, Cost); }
                case EntityTypes.ProductPlum: { return new ProductPlum(NameOfProduct, Cost); }
                case EntityTypes.ProductRaspberry: { return new ProductRaspberry(NameOfProduct, Cost); }
                case EntityTypes.ProductStrawberry: { return new ProductStrawberry(NameOfProduct, Cost); }
                case EntityTypes.ProductTomato: { return new ProductTomato(NameOfProduct, Cost); }
                case EntityTypes.ProductWaterMelon: { return new ProductWaterMelon(NameOfProduct, Cost); }

                default: { return new ProductApple(NameOfProduct, Cost); }
            }
        }
    }
}
