using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IStorageItemRepository
    {
        void Insert(Product product, string nameOfStorage);
        StorageItem SelectByNameOfStorageAndProduct(string nameOfStorage, string nameOfProduct);
        void Update(Product product, string nameOfStorage);
        void Delete(string nameOfStorage, string nameOfProduct);
        IEnumerable<StorageItem> Select(string nameOfStorage);
    }
}
