using ServerApplication.Entities.Products;
using ServerApplication.Entities;
using ServerApplication.FactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.FactoryFolder
{
    public static class EntityFactory
    {
        public static Entity Create(EntityTypes entityType)
        {
            switch (entityType)
            {
                case EntityTypes.ProductApple: { return new ProductApple(); }
                case EntityTypes.ProductBanana: { return new ProductBanana(); }
                case EntityTypes.ProductBlueberry: { return new ProductBlueberry(); }
                case EntityTypes.ProductCabbage: { return new ProductCabbage(); }
                case EntityTypes.ProductCherry: { return new ProductCherry(); }
                case EntityTypes.ProductGrape: { return new ProductGrape(); }
                case EntityTypes.ProductMandarin: { return new ProductMandarin(); }
                case EntityTypes.ProductMango: { return new ProductMango(); }
                case EntityTypes.ProductOrange: { return new ProductOrange(); }
                case EntityTypes.ProductPear: { return new ProductPear(); }
                case EntityTypes.ProductPlum: { return new ProductPlum(); }
                case EntityTypes.ProductRaspberry: { return new ProductRaspberry(); }
                case EntityTypes.ProductStrawberry: { return new ProductStrawberry(); }
                case EntityTypes.ProductTomato: { return new ProductTomato(); }
                case EntityTypes.ProductWaterMelon: { return new ProductWaterMelon(); }

                case EntityTypes.Storage: { return new Storage(); }
                case EntityTypes.StorageItem: { return new StorageItem(); }
                case EntityTypes.MoneyItemValue: { return new MoneyItemValue(); }

                default: { return new ProductApple(); }
            }
        }
    }
}
