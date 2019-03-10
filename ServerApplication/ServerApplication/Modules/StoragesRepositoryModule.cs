using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Repositories.Implementations;

namespace ServerApplication.Modules
{
    public class StoragesRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<StorageRepository>().As<IStorageRepository>();
            base.Load(objContainer);
        }
    }
}
