using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Interfaces.Products;
using ServerApplication.Services.Interfaces;
using ServerApplication.RepositoryFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ServerApplication.FactoryFolder;

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
            this.productAppleRepository = (IProductAppleRepository)RepositoryFactory.Create(EntityTypes.ProductApple);
            this.productBananaRepository = (IProductBananaRepository)RepositoryFactory.Create(EntityTypes.ProductBanana);
            this.productCabbageRepository = (IProductCabbageRepository)RepositoryFactory.Create(EntityTypes.ProductCabbage);
            this.productOrangeRepository = (IProductOrangeRepository)RepositoryFactory.Create(EntityTypes.ProductOrange);
            this.productTomatoRepository = (IProductTomatoRepository)RepositoryFactory.Create(EntityTypes.ProductTomato);
            this.productWatermelonRepository = (IProductWaterMelonRepository)RepositoryFactory.Create(EntityTypes.ProductWaterMelon);
            this.productPearRepository = (IProductPearRepository)RepositoryFactory.Create(EntityTypes.ProductPear);
            this.productCherryRepository = (IProductCherryRepository)RepositoryFactory.Create(EntityTypes.ProductCherry);
            this.productOrangeRepository = (IProductOrangeRepository)RepositoryFactory.Create(EntityTypes.ProductOrange);
            this.productStrawberryRepository = (IProductStrawberryRepository)RepositoryFactory.Create(EntityTypes.ProductStrawberry);
            this.productGrapeRepository = (IProductGrapeRepository)RepositoryFactory.Create(EntityTypes.ProductGrape);
            this.productMangoRepository = (IProductMangoRepository)RepositoryFactory.Create(EntityTypes.ProductMango);
            this.productBlueberryRepository = (IProductBlueberryRepository)RepositoryFactory.Create(EntityTypes.ProductBlueberry);
            this.productPlumRepository = (IProductPlumRepository)RepositoryFactory.Create(EntityTypes.ProductPlum);
            this.productRaspberryRepository = (IProductRaspberryRepository)RepositoryFactory.Create(EntityTypes.ProductRaspberry);
            this.productMandarinRepository = (IProductMandarinRepository)RepositoryFactory.Create(EntityTypes.ProductMandarin);
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
