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
        private IProductAppleRepository productRepository;

        public MoneyItemValueService(IStorageItemRepository storageItemRepository, IProductAppleRepository productRepository)
        {
            this.storageItemRepository = storageItemRepository;
            this.productRepository = productRepository;
        }

        private List<MoneyItemValue> GetStorageMoneyItemValues(NameOfStorage nameOfStorage)
        {
            List<StorageItem> storageItems = this.storageItemRepository.Select(nameOfStorage).ToList();
            List<MoneyItemValue> moneyItemValues = new List<MoneyItemValue>();
            storageItems.ForEach(storageItem =>
            {
                ProductApple product = this.productRepository.SelectByName(storageItem.NameOfProduct);
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
