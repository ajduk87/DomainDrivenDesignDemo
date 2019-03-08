using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IMoneyItemValueService
    {
        MoneyItemValue Max(NameOfStorage nameOfStorage);
        MoneyItemValue Min(NameOfStorage nameOfStorage);
        MoneyItemValue Avg(NameOfStorage nameOfStorage);
        MoneyItemValue Sum(NameOfStorage nameOfStorage);
    }
}
