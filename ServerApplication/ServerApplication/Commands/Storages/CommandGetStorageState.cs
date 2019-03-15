using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.Storages
{
    public class CommandGetStorageState : ICommmandStorage
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandGetStorageState(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForGetStorageState(rq);

        private void RequestForGetStorageState(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];
                string kindOfStorage = rq.Args[1];

                IStorageItemService storageItemsService = container.Resolve<IStorageItemService>();
                NameOfStorage nameOfStorage = new NameOfStorage { Content = nameOfStorageContent };
                List<StorageItem> storageItems = storageItemsService.GetStateOfStorage(nameOfStorage).ToList();



                string response = string.Empty;
                storageItems.ForEach(storageItem =>
                {
                    response += storageItem.NameOfProduct.Content + " " + storageItem.CountOfProduct + System.Environment.NewLine;
                });
                helperClass.writeResponse(response);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }

        }
    }
}
