using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.Callers
{
    public class CommandMoneyValueCaller
    {
        private IContainer container;

        public CommandMoneyValueCaller(IContainer container)
        {
            this.container = container;
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = container.ResolveKeyed<ICommand>(typeof(CommandMoneyValue));
            command.Execute(numberOfRequest, rq);
        }
    }
}
