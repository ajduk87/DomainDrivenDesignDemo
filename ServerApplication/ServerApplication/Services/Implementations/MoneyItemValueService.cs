using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Interfaces.Products;
using ServerApplication.RepositoryFactoryFolder;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Services.Implementations
{
    public class MoneyItemValueService : IMoneyItemValueService
    {
        private IStorageItemRepository storageItemRepository;
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

        public MoneyItemValueService()
        {
            this.storageItemRepository = (IStorageItemRepository)RepositoryFactory.Create(RepositoryTypes.Storage);
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

        private List<MoneyItemValue> GetStorageMoneyItemValues(NameOfStorage nameOfStorage)
        {
            List<StorageItem> storageItems = this.storageItemRepository.Select(nameOfStorage).ToList();
            List<MoneyItemValue> moneyItemValues = new List<MoneyItemValue>();
            storageItems.ForEach(storageItem =>
            {
                ProductApple product = this.productAppleRepository.SelectByName(storageItem.NameOfProduct);
                MoneyItemValue moneyItemValue = new MoneyItemValue
                {
                    Value = storageItem.CountOfProduct * product.Cost.Value,
                    Currency = new Currency { Content = "EUR" }
                };
                moneyItemValues.Add(moneyItemValue);
            });
            return moneyItemValues;
        }

        public MoneyItemValue Max(NameOfStorage nameOfStorage)
        {
            List<MoneyItemValue> moneyItemValues = GetStorageMoneyItemValues(nameOfStorage);
            MoneyItemValue maxMoneyItemValue = new MoneyItemValue
            {
                Value = moneyItemValues.Max(moneyItemValue => moneyItemValue.Value),
                Currency = moneyItemValues.First().Currency
            };
            return maxMoneyItemValue;

        }
        public MoneyItemValue Min(NameOfStorage nameOfStorage)
        {
            List<MoneyItemValue> moneyItemValues = GetStorageMoneyItemValues(nameOfStorage);
            MoneyItemValue maxMoneyItemValue = new MoneyItemValue
            {
                Value = moneyItemValues.Min(moneyItemValue => moneyItemValue.Value),
                Currency = moneyItemValues.First().Currency
            };
            return maxMoneyItemValue;
        }
        public MoneyItemValue Avg(NameOfStorage nameOfStorage)
        {
            List<MoneyItemValue> moneyItemValues = GetStorageMoneyItemValues(nameOfStorage);
            MoneyItemValue maxMoneyItemValue = new MoneyItemValue
            {
                Value = moneyItemValues.Average(moneyItemValue => moneyItemValue.Value),
                Currency = moneyItemValues.First().Currency
            };
            return maxMoneyItemValue;
        }
        public MoneyItemValue Sum(NameOfStorage nameOfStorage)
        {
            List<MoneyItemValue> moneyItemValues = GetStorageMoneyItemValues(nameOfStorage);
            MoneyItemValue maxMoneyItemValue = new MoneyItemValue
            {
                Value = moneyItemValues.Sum(moneyItemValue => moneyItemValue.Value),
                Currency = moneyItemValues.First().Currency
            };
            return maxMoneyItemValue;
        }
    }
}
