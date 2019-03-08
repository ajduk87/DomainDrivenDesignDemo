using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Implementations
{
    public class StorageService : IStorageService
    {
        private IStorageRepository storageRepository;

        public StorageService(IStorageRepository storageRepository)
        {
            this.storageRepository = storageRepository;
        }

        public void Create(Storage storage)
        {
            this.storageRepository.Insert(storage);
        }

        public IEnumerable<Storage> GetAll()
        {
            return this.storageRepository.SelectAll();
        }

        public Storage Enter(NameOfStorage name)
        {
            return this.storageRepository.SelectByName(name);
        }
    }
}
