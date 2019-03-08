using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IStorageItemService
    {
        void Insert(StorageItem storageItem);
        StorageItem Get(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct);
        void Update(StorageItem storageItem);
        void Delete(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct);
        IEnumerable<StorageItem> GetStateOfStorage(NameOfStorage nameOfStorage);
        bool IsProductExistsInStorage(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct);
    }
}
