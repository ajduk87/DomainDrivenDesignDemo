using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Requests.Storages
{
    public class RequestEnterInSpecificStorage : IRequestStorage
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestEnterInSpecificStorage(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForEnterInSpecificStorage(rq);

        private void RequestForEnterInSpecificStorage(Request rq)
        {
            try
            {
                string nameOfStorageContent = rq.Args[0];

                IStorageService storageService = container.Resolve<IStorageService>();
                NameOfStorage nameOfStorage = new NameOfStorage(nameOfStorageContent);
                Storage storage = storageService.Enter(nameOfStorage);


                string response = storage.NameOfStorage.Content + " " + storage.KindOfStorage.Content;
                helperClass.writeResponse(response);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
