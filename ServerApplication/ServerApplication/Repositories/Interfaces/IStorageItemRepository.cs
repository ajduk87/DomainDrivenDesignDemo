using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IStorageItemRepository
    {
        void Insert(StorageItem storageItem);
        StorageItem SelectByNameOfStorageAndProduct(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct);
        void Update(StorageItem storageItem);
        void Delete(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct);
        IEnumerable<StorageItem> Select(NameOfStorage nameOfStorage);
    }
}
