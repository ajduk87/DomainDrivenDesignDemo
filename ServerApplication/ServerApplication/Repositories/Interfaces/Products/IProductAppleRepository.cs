using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.RepositoryFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Repositories.Interfaces.Products
{
    public interface IProductAppleRepository : IRepository
    {
        void Insert(ProductApple product);
        ProductApple SelectByName(NameOfProduct name);
        void Update(ProductApple product);
        void Delete(NameOfProduct name);
    }
}
