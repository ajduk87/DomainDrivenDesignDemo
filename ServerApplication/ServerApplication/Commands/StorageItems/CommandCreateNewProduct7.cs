using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.FactoryFolder;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Commands.StorageItems
{
    public class CommandCreateNewProduct7 : ICommandStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandCreateNewProduct7(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForCreateNewProduct7(rq);

        private void RequestForCreateNewProduct7(Request rq)
        {
            try
            {
                string nameOfProduct = rq.Args[0];
                string unitCostString = rq.Args[1];
                string countString = rq.Args[2];
                string nameOfStorage = rq.Args[3];


                IProductService productService = container.Resolve<IProductService>();
                ProductApple product = (ProductApple)ProductFactory.Create(EntityTypes.ProductApple, nameOfProduct, unitCostString, "EUR");
                productService.Create(product);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                StorageItem storageItem = (StorageItem)StorageItemFactory.Create(EntityTypes.StorageItem, nameOfProduct, nameOfStorage, countString);
                storageItemService.Insert(storageItem);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
