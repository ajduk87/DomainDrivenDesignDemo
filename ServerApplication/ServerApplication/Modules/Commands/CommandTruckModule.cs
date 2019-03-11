using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Commands;
using ServerApplication.Commands.Trucks;

namespace ServerApplication.Modules.Commands
{
    public class CommandTruckModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck1));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck2));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck3));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck4));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck5));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck6));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck7));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck8));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck9));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandInsertNewTruck10));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandSendingTruck));
            objContainer.RegisterType<ICommandTruck>().Keyed<ICommand>(typeof(CommandDeliveredProductsByTruck));
            base.Load(objContainer);
        }
    }
}
