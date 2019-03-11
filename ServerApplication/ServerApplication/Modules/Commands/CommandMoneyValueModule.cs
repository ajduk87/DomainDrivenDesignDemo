using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Commands;
using ServerApplication.Commands.Storages;
using ServerApplication.Commands.StorageItems;
using ServerApplication.Commands.MoneyValue;

namespace ServerApplication.Modules.Commands
{
    public class CommandMoneyValueModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostAvg));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMax));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostSum));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin1));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin1));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin2));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin3));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin4));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin5));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin6));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin7));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin8));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin9));
            objContainer.RegisterType<ICommandMoneyValue>().Keyed<ICommandStorageItem>(typeof(CommandProductsCostMin10));
            base.Load(objContainer);
        }
    }
}
