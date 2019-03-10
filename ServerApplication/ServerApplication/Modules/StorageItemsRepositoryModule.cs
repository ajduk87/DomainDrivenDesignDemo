using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Repositories.Implementations;
using ServerApplication.Repositories.Interfaces;

namespace ServerApplication.Modules
{
    public class StorageItemsRepositoryModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<StorageItemRepository>().As<IStorageItemRepository>();
            base.Load(objContainer);
        }
    }
}
