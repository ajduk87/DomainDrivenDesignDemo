using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.RepositoryFactoryFolder;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Implementations
{
    public class StorageItemService : IStorageItemService
    {
        private IStorageItemRepository storageItemRepository;

        public StorageItemService()
        {
            this.storageItemRepository = (IStorageItemRepository)RepositoryFactory.Create(RepositoryTypes.Storage);
        }

        public void Insert(StorageItem storageItem)
        {
            this.storageItemRepository.Insert(storageItem);
        }
        public StorageItem Get(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct)
        {
            return this.storageItemRepository.SelectByNameOfStorageAndProduct(nameOfStorage, nameOfProduct);
        }
        public void Update(StorageItem storageItem)
        {
            this.storageItemRepository.Update(storageItem);
        }
        public void Delete(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct)
        {
            this.storageItemRepository.Delete(nameOfStorage, nameOfProduct);
        }
        public IEnumerable<StorageItem> GetStateOfStorage(NameOfStorage nameOfStorage)
        {
            return this.storageItemRepository.Select(nameOfStorage);
        }

        public bool IsProductExistsInStorage(NameOfStorage nameOfStorage, NameOfProduct nameOfProduct)
        {
            StorageItem storageItem = this.storageItemRepository.SelectByNameOfStorageAndProduct(nameOfStorage, nameOfProduct);
            bool isExist = true;
            if (storageItem == null)
            {
                isExist = false;
            }
            return isExist;
        }

    }
}
