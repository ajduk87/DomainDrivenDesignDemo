using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.FactoryFolder;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Commands.StorageItems
{
    public class CommandCreateNewProduct9 : ICommandStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandCreateNewProduct9(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => requestForCreateNewProduct9(rq);

        private void requestForCreateNewProduct9(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];


                IProductService productService = container.Resolve<IProductService>();
                ProductApple product = (ProductApple)EntityFactory.Create(EntityTypes.ProductApple);
                product.NameOfProduct = new NameOfProduct { Content = nameOfProduct };
                product.Cost = new UnitCost
                {
                    Value = Convert.ToDouble(unitCostString),
                    Currency = new Currency { Content = "EUR" }
                };

                productService.Create(product);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                StorageItem storageItem = new StorageItem
                {
                    NameOfStorage = new NameOfStorage { Content = nameOfStorage },
                    NameOfProduct = new NameOfProduct { Content = nameOfProduct },
                    CountOfProduct = Convert.ToInt32(countString)
                };
                storageItemService.Insert(storageItem);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
