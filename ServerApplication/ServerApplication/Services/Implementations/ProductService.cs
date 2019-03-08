using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Implementations
{
    public class ProductService : IProductService
    {
        private IProductRepository productRepository;

        public ProductService(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public void Create(Product product)
        {
            this.productRepository.Insert(product);
        }

        public Product Get(NameOfProduct name)
        {
            return this.productRepository.SelectByName(name);
        }

        public void Update(Product product)
        {
            this.productRepository.Update(product);
        }

        public void Delete(NameOfProduct name)
        {
            this.productRepository.Delete(name);
        }

    }
}
