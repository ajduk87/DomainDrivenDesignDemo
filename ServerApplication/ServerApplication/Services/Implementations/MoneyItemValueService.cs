using ServerApplication.Entities;
using ServerApplication.Entities.Products;
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


        public MoneyItemValueService(IStorageItemRepository storageItemRepository, IProductAppleRepository productAppleRepository, IProductBananaRepository productBananaRepository, IProductCabbageRepository productCabbageRepository, IProductOrangeRepository productOrangeRepository, IProductTomatoRepository productTomatoRepository, IProductWaterMelonRepository productWatermelonRepository, IProductPearRepository productPearRepository, IProductCherryRepository productCherryRepository, IProductStrawberryRepository productStrawberryRepository, IProductGrapeRepository productGrapeRepository, IProductMangoRepository productMangoRepository, IProductBlueberryRepository productBlueberryRepository, IProductPlumRepository productPlumRepository, IProductRaspberryRepository productRaspberryRepository, IProductMandarinRepository productMandarinRepository)
        {
            this.storageItemRepository = storageItemRepository;
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
