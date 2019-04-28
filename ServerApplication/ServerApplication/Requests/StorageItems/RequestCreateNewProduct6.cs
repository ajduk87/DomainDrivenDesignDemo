using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.FactoryFolder;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Requests.StorageItems
{
    public class RequestCreateNewProduct6 : IRequestStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestCreateNewProduct6(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForCreateNewProduct6(rq);

        private void RequestForCreateNewProduct6(Request rq)
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
