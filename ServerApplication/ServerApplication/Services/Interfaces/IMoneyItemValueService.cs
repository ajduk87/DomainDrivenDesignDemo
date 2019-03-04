using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IMoneyItemValueService
    {
        MoneyItemValue Max(string nameOfStorage);
        MoneyItemValue Min(string nameOfStorage);
        MoneyItemValue Avg(string nameOfStorage);
        MoneyItemValue Sum(string nameOfStorage);
    }
}
