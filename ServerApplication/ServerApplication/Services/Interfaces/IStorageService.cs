using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IStorageService
    {
        void Insert(Storage storage);
        IEnumerable<Storage> GetAll();
        Storage Enter(string name);
    }
}
