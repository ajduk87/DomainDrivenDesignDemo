using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IStorageItemService
    {
        void Insert(string name);
        StorageItem Get(string name);
        void Update(StorageItem storageItem);
        void Delete(string name);

        double Min(Storage storage);
        double Max(Storage storage);
        double Avg(Storage storage);
        double Sum(Storage storage);
    }
}
