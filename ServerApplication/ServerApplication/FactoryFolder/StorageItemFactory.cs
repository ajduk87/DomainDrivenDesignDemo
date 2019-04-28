using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.FactoryFolder
{
    public static class StorageItemFactory
    {
        public static Entity Create(EntityTypes entityType, string nameOfProduct, string nameOfStorage, string countString)
        {
            switch (entityType)
            {
                case EntityTypes.StorageItem:
                {
                    return new StorageItem
                    {
                        NameOfStorage = new NameOfStorage(nameOfStorage),
                        NameOfProduct = new NameOfProduct(nameOfProduct),
                        CountOfProduct = Convert.ToInt32(countString)
                    };
                }

                default: { return new StorageItem(); }
            }
        }
    }
}
