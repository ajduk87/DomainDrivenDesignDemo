using Autofac;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.StorageItems
{
    public class CommandDeleteProductFromStorage : ICommandStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandDeleteProductFromStorage(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => requestForDeleteProductFromStorage(rq);

        private void requestForDeleteProductFromStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string nameOfProductContent = rq.Args[1];

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                NameOfProduct nameOfProduct = new NameOfProduct { Content = nameOfProductContent };
                storageItemService.Delete(nameOfStorage, nameOfProduct);

            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
