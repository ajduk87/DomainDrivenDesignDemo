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
        public static Entity Create(EntityTypes entityType)
        {
            switch (entityType)
            {
              
                case EntityTypes.Storage: { return new Storage(); }
                case EntityTypes.StorageItem: { return new StorageItem(); }
                case EntityTypes.MoneyItemValue: { return new MoneyItemValue(); }

                default: { return new Storage(); }
            }
        }
    }
}
