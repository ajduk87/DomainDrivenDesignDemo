using Autofac;
using ServerApplication.Commands.Trucks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.Callers
{
    public class CommandTruckCaller
    {
        private IContainer container;
        private Dictionary<long, ICommandTruck> dictCommands;

        public CommandTruckCaller(IContainer container)
        {
            this.container = container;

            dictCommands = new Dictionary<long, ICommandTruck>();
            dictCommands.Add(42, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck1)));
            dictCommands.Add(43, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck2)));
            dictCommands.Add(44, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck3)));
            dictCommands.Add(45, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck4)));
            dictCommands.Add(46, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck5)));
            dictCommands.Add(47, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck6)));
            dictCommands.Add(48, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck7)));
            dictCommands.Add(49, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck8)));
            dictCommands.Add(50, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck9)));
            dictCommands.Add(51, container.ResolveKeyed<ICommandTruck>(typeof(CommandInsertNewTruck10)));
            dictCommands.Add(52, container.ResolveKeyed<ICommandTruck>(typeof(CommandSendingTruck)));
            dictCommands.Add(53, container.ResolveKeyed<ICommandTruck>(typeof(CommandDeliveredProductsByTruck)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = dictCommands[numberOfRequest];
            command.Execute(rq);
        }
    }
}
