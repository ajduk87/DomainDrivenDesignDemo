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
    public class StorageService : IStorageService
    {
        private IStorageRepository storageRepository;

        public StorageService()
        {
            this.storageRepository = (IStorageRepository)RepositoryFactory.Create(RepositoryTypes.Storage);
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
