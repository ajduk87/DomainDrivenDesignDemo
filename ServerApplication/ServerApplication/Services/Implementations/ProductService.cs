using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Interfaces.Products;
using ServerApplication.Services.Interfaces;
using ServerApplication.RepositoryFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApplication.Entities.Products;

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

        public ProductService()
        {
            this.productAppleRepository = (IProductAppleRepository)RepositoryFactory.Create(RepositoryTypes.ProductApple);
            this.productBananaRepository = (IProductBananaRepository)RepositoryFactory.Create(RepositoryTypes.ProductBanana);
            this.productCabbageRepository = (IProductCabbageRepository)RepositoryFactory.Create(RepositoryTypes.ProductCabbage);
            this.productOrangeRepository = (IProductOrangeRepository)RepositoryFactory.Create(RepositoryTypes.ProductOrange);
            this.productTomatoRepository = (IProductTomatoRepository)RepositoryFactory.Create(RepositoryTypes.ProductTomato);
            this.productWatermelonRepository = (IProductWaterMelonRepository)RepositoryFactory.Create(RepositoryTypes.ProductWaterMelon);
            this.productPearRepository = (IProductPearRepository)RepositoryFactory.Create(RepositoryTypes.ProductPear);
            this.productCherryRepository = (IProductCherryRepository)RepositoryFactory.Create(RepositoryTypes.ProductCherry);
            this.productOrangeRepository = (IProductOrangeRepository)RepositoryFactory.Create(RepositoryTypes.ProductOrange);
            this.productStrawberryRepository = (IProductStrawberryRepository)RepositoryFactory.Create(RepositoryTypes.ProductStrawberry);
            this.productGrapeRepository = (IProductGrapeRepository)RepositoryFactory.Create(RepositoryTypes.ProductGrape);
            this.productMangoRepository = (IProductMangoRepository)RepositoryFactory.Create(RepositoryTypes.ProductMango);
            this.productBlueberryRepository = (IProductBlueberryRepository)RepositoryFactory.Create(RepositoryTypes.ProductBlueberry);
            this.productPlumRepository = (IProductPlumRepository)RepositoryFactory.Create(RepositoryTypes.ProductPlum);
            this.productRaspberryRepository = (IProductRaspberryRepository)RepositoryFactory.Create(RepositoryTypes.ProductRaspberry);
            this.productMandarinRepository = (IProductMandarinRepository)RepositoryFactory.Create(RepositoryTypes.ProductMandarin);
        }

        public void Create(ProductApple product)
        {
            this.productAppleRepository.Insert(product);
        }

        public ProductApple Get(NameOfProduct name)
        {
            return this.productAppleRepository.SelectByName(name);
        }

        public void Update(ProductApple product)
        {
            this.productAppleRepository.Update(product);
        }

        public void Delete(NameOfProduct name)
        {
            this.productAppleRepository.Delete(name);
        }

    }
}
