using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IProductService
    {
        void Create(Product product);
        Product Get(NameOfProduct name);
        void Update(Product product);
        void Delete(NameOfProduct name);
    }
}
