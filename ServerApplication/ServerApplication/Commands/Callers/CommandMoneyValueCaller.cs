using Autofac;
using ServerApplication.Commands.MoneyValue;
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
        private Dictionary<long, ICommandMoneyValue> dictCommands;

        public CommandMoneyValueCaller(IContainer container)
        {
            this.container = container;

            dictCommands = new Dictionary<long, ICommandMoneyValue>();
            dictCommands.Add(27, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin1)));
            dictCommands.Add(28, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin2)));
            dictCommands.Add(29, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin3)));
            dictCommands.Add(30, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin4)));
            dictCommands.Add(31, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin5)));
            dictCommands.Add(32, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin6)));
            dictCommands.Add(33, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin7)));
            dictCommands.Add(34, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin8)));
            dictCommands.Add(35, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin9)));
            dictCommands.Add(36, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMin10)));
            dictCommands.Add(37, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostMax)));
            dictCommands.Add(38, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostAvg)));
            dictCommands.Add(39, container.ResolveKeyed<ICommandMoneyValue>(typeof(CommandProductsCostSum)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = dictCommands[numberOfRequest];
            command.Execute(rq);
        }
    }
}
