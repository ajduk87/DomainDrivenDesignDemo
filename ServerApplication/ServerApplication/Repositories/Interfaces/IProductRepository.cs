using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces
{
    public interface IProductRepository
    {
        void Insert(Product product);
        Product SelectByName(string name);
        void Update(Product product);
        void Delete(string name);
    }
}
