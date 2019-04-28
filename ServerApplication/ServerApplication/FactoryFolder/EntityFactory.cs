using ServerApplication.Entities.Products;
using ServerApplication.Entities;
using ServerApplication.FactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServerApplication.Entities.ValueObjects;

namespace ServerApplication.FactoryFolder
{
    public static class EntityFactory
    {
        public static Entity Create(EntityTypes entityType, string nameOfStorage = null,string nameOfProduct = null, string countString = null)
        {
            switch (entityType)
            {
                case EntityTypes.Storage: { return new Storage(); }
                case EntityTypes.StorageItem:
                {
                        return new StorageItem
                        {
                            NameOfStorage = new NameOfStorage(nameOfStorage),
                            NameOfProduct = new NameOfProduct(nameOfProduct),
                            CountOfProduct = Convert.ToInt32(countString)
                        };
                }
                case EntityTypes.MoneyItemValue: { return new MoneyItemValue(); }

                default: { return new MoneyItemValue(); }
            }
        }
    }
}
