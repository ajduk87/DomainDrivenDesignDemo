using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Commands;
using ServerApplication.Commands.Storages;
using ServerApplication.Commands.StorageItems;

namespace ServerApplication.Modules.Commands
{
    public class CommandStorageItemModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct1));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct2));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct3));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct4));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct5));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct6));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct7));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct8));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct9));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCreateNewProduct10));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandCheckIsProductExists));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandDeleteProductFromStorage));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandGetProductInfo));
            objContainer.RegisterType<ICommandStorageItem>().Keyed<ICommandStorageItem>(typeof(CommandUpdateProduct));
            base.Load(objContainer);
        }
    }
}
