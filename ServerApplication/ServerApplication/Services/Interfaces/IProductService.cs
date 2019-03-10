using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Interfaces
{
    public interface IProductService
    {
        void Create(ProductApple product);
        ProductApple Get(NameOfProduct name);
        void Update(ProductApple product);
        void Delete(NameOfProduct name);
    }
}
