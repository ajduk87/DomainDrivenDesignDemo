using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.RepositoryFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IStorageRepository : IRepository
    {
        void Insert(Storage storage);
        IEnumerable<Storage> SelectAll();
        Storage SelectByName(NameOfStorage name);
    }
}
