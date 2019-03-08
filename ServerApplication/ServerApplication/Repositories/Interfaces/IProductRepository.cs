using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Insert(Product product);
        Product SelectByName(NameOfProduct name);
        void Update(Product product);
        void Delete(NameOfProduct name);
    }
}
