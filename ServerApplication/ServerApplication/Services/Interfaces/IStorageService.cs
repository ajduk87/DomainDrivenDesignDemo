using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IStorageService
    {
        void Create(Storage storage);
        IEnumerable<Storage> GetAll();
        Storage Enter(NameOfStorage name);
    }
}
