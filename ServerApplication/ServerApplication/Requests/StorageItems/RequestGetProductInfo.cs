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

namespace ServerApplication.Requests.StorageItems
{
    public class RequestGetProductInfo : IRequestStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestGetProductInfo(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForGetProductInfo(rq);

        private void RequestForGetProductInfo(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];

                IProductService productService = container.Resolve<IProductService>();
                NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
                ProductApple product = productService.Get(nameOfProduct);

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
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
