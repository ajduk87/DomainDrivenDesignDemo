using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.StorageItems
{
    public class CommandGetProductInfo : ICommandStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandGetProductInfo(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => requestForGetProductInfo(rq);

        private void requestForGetProductInfo(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];

                IProductService productService = container.Resolve<IProductService>();
                NameOfProduct nameOfProduct = new NameOfProduct { Content = nameOfProductContent };
                ProductApple product = productService.Get(nameOfProduct);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                StorageItem storageItem = storageItemService.Get(nameOfStorage, product.NameOfProduct);


                string response = product.NameOfProduct.Content + " " + product.Cost.Value + " " + storageItem.CountOfProduct;
                helperClass.writeResponse(response);

            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);

            }
        }
    }
}
