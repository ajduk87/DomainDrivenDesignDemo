using Autofac;
using ServerApplication.Commands.StorageItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.Callers
{
    public class CommandStorageItemCaller
    {
        private IContainer container;
        private Dictionary<long, ICommandStorageItem> dictCommands;

        public CommandStorageItemCaller(IContainer container)
        {
            this.container = container;

            dictCommands = new Dictionary<long, ICommandStorageItem>();
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct1)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct2)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct3)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct4)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct5)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct6)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct7)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct8)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct9)));
            dictCommands.Add(11, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCreateNewProduct10)));
            dictCommands.Add(25, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandGetProductInfo)));
            dictCommands.Add(26, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandCheckIsProductExists)));
            dictCommands.Add(40, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandUpdateProduct)));
            dictCommands.Add(41, container.ResolveKeyed<ICommandStorageItem>(typeof(CommandDeleteProductFromStorage)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = dictCommands[numberOfRequest];
            command.Execute(rq);
        }
    }
}
