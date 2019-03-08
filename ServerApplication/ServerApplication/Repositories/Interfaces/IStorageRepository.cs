using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IStorageRepository
    {
        void Insert(Storage storage);
        IEnumerable<Storage> SelectAll();
        Storage SelectByName(NameOfStorage name);
    }
}
