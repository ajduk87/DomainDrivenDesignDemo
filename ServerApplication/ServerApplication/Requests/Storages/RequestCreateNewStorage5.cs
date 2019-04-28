using Autofac;
using ServerApplication.Entities;
using ServerApplication.Entities.ValueObjects;
using ServerApplication.FactoryFolder;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Requests.Storages
{
    public class RequestCreateNewStorage5 : IRequestStorage
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestCreateNewStorage5(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForCreateNewStorage5(rq);

        private void RequestForCreateNewStorage5(Request rq)
        {
            try
            {
                string name = rq.Args[0];
                string kind = rq.Args[1];

                IStorageService storageService = container.Resolve<IStorageService>();
                Storage strorage = (Storage)EntityFactory.Create(EntityTypes.Storage, name, kind);
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
