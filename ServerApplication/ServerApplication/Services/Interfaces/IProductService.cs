using ServerApplication.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IProductService
    {
        void Insert(string name);
        Product Get(string name);
        void Update(Product product);
        void Delete(string name);
    }
}
