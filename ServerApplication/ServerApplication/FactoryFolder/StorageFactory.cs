using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.FactoryFolder
{
    public static class StorageFactory
    {
        public static Entity Create(EntityTypes entityType, string nameOfStorage, string kindOfStorage)
        {
            switch (entityType)
            {
                case EntityTypes.Storage: {
                        return new Storage
                        {
                            NameOfStorage = new NameOfStorage(nameOfStorage),
                            KindOfStorage = new KindOfStorage(kindOfStorage)
                        };
                    }
                default: { return new Storage(); }
            }
        }
    }
}
