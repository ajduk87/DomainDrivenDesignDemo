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
    public class CommandCreateNewStorage5 : ICommmandStorage
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandCreateNewStorage5(IContainer container)
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
                Storage strorage = new Storage
                {
                    NameOfStorage = new NameOfStorage { Content = name },
                    KindOfStorage = new KindOfStorage { Content = kind }
                };
                storageService.Create(strorage);
            }
            catch (Exception ex)
            {
                helperClass.writeExceptionMessage(ex.Message);
            }
        }
    }
}
