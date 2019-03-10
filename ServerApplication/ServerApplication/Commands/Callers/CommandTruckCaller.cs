using Autofac;
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

        public CommandTruckCaller(IContainer container)
        {
            this.container = container;
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = container.ResolveKeyed<ICommand>(typeof(CommandTruck));
            command.Execute(numberOfRequest, rq);
        }
    }
}
