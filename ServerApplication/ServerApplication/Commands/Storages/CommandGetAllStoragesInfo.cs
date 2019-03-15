using Autofac;
using ServerApplication.Entities;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.Storages
{
    public class CommandGetAllStoragesInfo : ICommmandStorage
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandGetAllStoragesInfo(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForGetAllStoragesInfo();

        private void RequestForGetAllStoragesInfo()
        {
            try
            {
                IStorageService storageService = container.Resolve<IStorageService>();
                List<Storage> storages = storageService.GetAll().ToList();


                string response = string.Empty;
                storages.ForEach(storage =>
                {
                    response += storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content + System.Environment.NewLine;
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
