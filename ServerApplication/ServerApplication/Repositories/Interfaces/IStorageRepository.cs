using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IStorageRepository
    {
        void Insert(Storage storage);
        IEnumerable<Storage> Select();
        Storage SelectByName(string name);
    }
}
