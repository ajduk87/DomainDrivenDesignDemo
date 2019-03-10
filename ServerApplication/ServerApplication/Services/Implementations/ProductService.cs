using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Interfaces.Products;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Implementations
{
    public class ProductService : IProductService
    {
        private IProductAppleRepository productAppleRepository;
        private IProductBananaRepository productBananaRepository;
        private IProductCabbageRepository productCabbageRepository;
        private IProductOrangeRepository productOrangeRepository;
        private IProductTomatoRepository productTomatoRepository;
        private IProductWaterMelonRepository productWatermelonRepository;
        private IProductPearRepository productPearRepository;
        private IProductCherryRepository productCherryRepository;
        private IProductStrawberryRepository productStrawberryRepository;
        private IProductGrapeRepository productGrapeRepository;
        private IProductMangoRepository productMangoRepository;
        private IProductBlueberryRepository productBlueberryRepository;
        private IProductPlumRepository productPlumRepository;
        private IProductRaspberryRepository productRaspberryRepository;
        private IProductMandarinRepository productMandarinRepository;

        public ProductService(IProductAppleRepository productAppleRepository, IProductBananaRepository productBananaRepository, IProductCabbageRepository productCabbageRepository, IProductOrangeRepository productOrangeRepository, IProductTomatoRepository productTomatoRepository, IProductWaterMelonRepository productWatermelonRepository, IProductPearRepository productPearRepository, IProductCherryRepository productCherryRepository, IProductStrawberryRepository productStrawberryRepository, IProductGrapeRepository productGrapeRepository, IProductMangoRepository productMangoRepository, IProductBlueberryRepository productBlueberryRepository, IProductPlumRepository productPlumRepository, IProductRaspberryRepository productRaspberryRepository, IProductMandarinRepository productMandarinRepository)
        {
            this.productAppleRepository = productAppleRepository;
            this.productBananaRepository = productBananaRepository;
            this.productCabbageRepository = productCabbageRepository;
            this.productOrangeRepository = productOrangeRepository;
            this.productTomatoRepository = productTomatoRepository;
            this.productWatermelonRepository = productWatermelonRepository;
            this.productPearRepository = productPearRepository;
            this.productCherryRepository = productCherryRepository;
            this.productOrangeRepository = productOrangeRepository;
            this.productStrawberryRepository = productStrawberryRepository;
            this.productGrapeRepository = productGrapeRepository;
            this.productMangoRepository = productMangoRepository;
            this.productBlueberryRepository = productBlueberryRepository;
            this.productPlumRepository = productPlumRepository;
            this.productRaspberryRepository = productRaspberryRepository;
            this.productMandarinRepository = productMandarinRepository;
        }

        public void Create(Product product)
        {
            this.productAppleRepository.Insert(product);
        }

        public Product Get(NameOfProduct name)
        {
            return this.productAppleRepository.SelectByName(name);
        }

        public void Update(Product product)
        {
            this.productAppleRepository.Update(product);
        }

        public void Delete(NameOfProduct name)
        {
            this.productAppleRepository.Delete(name);
        }

    }
}
