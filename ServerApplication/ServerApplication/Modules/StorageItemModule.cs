using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Services.Implementations;
using ServerApplication.Repositories.Implementations;
using ServerApplication.Services.Interfaces;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.Entities;

namespace ServerApplication.Modules
{
    public class StorageItemModule : Module
    {
        public Discount Discount { get; set; }
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<StorageItemRepository>().As<IStorageItemRepository>();
            objContainer.RegisterType<StorageItemService>().As<IStorageItemService>();
            base.Load(objContainer);
        }
    }
}
