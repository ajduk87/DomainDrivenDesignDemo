using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Commands;

namespace ServerApplication.Modules
{
    public class CommandModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ICommand>().Keyed<ICommand>(typeof(CommandMoneyValue));
            objContainer.RegisterType<ICommand>().Keyed<ICommand>(typeof(CommandStorageItem));
            objContainer.RegisterType<ICommand>().Keyed<ICommand>(typeof(CommandTruck));
            objContainer.RegisterType<ICommand>().Keyed<ICommand>(typeof(CommmandStorage));
            base.Load(objContainer);
        }
    }
}
