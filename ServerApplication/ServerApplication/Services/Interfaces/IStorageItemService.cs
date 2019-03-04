﻿using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IStorageItemService
    {
        void Insert(Product product, string nameOfStorage);
        StorageItem Get(string nameOfStorage, string nameOfProduct);
        void Update(Product product, string nameOfStorage);
        void Delete(string nameOfStorage, string nameOfProduct);
        IEnumerable<StorageItem> Get(string nameOfStorage);
    }
}