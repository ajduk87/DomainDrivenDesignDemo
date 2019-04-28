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
    public class CommandCheckIsProductExists : ICommandStorageItem
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandCheckIsProductExists(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForCheckIsProductExists(rq);

        private void RequestForCheckIsProductExists(Request rq)
        {
            try
            {
                string nameOfProductContent = rq.Args[0];
                string nameOfStorageContent = rq.Args[1];

                IStorageItemService storageItemService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                NameOfProduct nameOfProduct = new NameOfProduct(nameOfProductContent);
                bool isExist = storageItemService.IsProductExistsInStorage(nameOfStorage, nameOfProduct);



                string response = string.Empty;
                if (isExist == true)
                {
                    response = "true";
                }
                else
                {
                    response = "false";
                }
                helperClass.writeResponse(response);

            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);

            }
        }
    }
}
