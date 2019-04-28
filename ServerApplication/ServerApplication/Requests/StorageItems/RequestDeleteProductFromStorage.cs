using Autofac;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Requests.StorageItems
{
    public class RequestDeleteProductFromStorage : IRequestStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestDeleteProductFromStorage(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForDeleteProductFromStorage(rq);

        private void RequestForDeleteProductFromStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string nameOfProductContent = rq.Args[1];

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
                storageItemService.Delete(nameOfStorage, nameOfProduct);

            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
