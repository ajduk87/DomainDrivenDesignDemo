using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Commands.Storages;

namespace ServerApplication.Commands.Callers
{
    public class CommmandStorageCaller
    {
        private IContainer container;
        private Dictionary<long, ICommmandStorage> dictCommands;

        public CommmandStorageCaller(IContainer container)
        {
            this.container = container;

            dictCommands = new Dictionary<long, ICommmandStorage>();
            dictCommands.Add(1, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage1)));
            dictCommands.Add(2, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage2)));
            dictCommands.Add(3, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage3)));
            dictCommands.Add(4, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage4)));
            dictCommands.Add(5, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage5)));
            dictCommands.Add(6, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage6)));
            dictCommands.Add(7, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage7)));
            dictCommands.Add(8, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage8)));
            dictCommands.Add(9, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage9)));
            dictCommands.Add(10, container.ResolveKeyed<ICommmandStorage>(typeof(CommandCreateNewStorage10)));
            dictCommands.Add(21, container.ResolveKeyed<ICommmandStorage>(typeof(CommandGetAllStoragesInfo)));
            dictCommands.Add(23, container.ResolveKeyed<ICommmandStorage>(typeof(CommandEnterInSpecificStorage)));
            dictCommands.Add(24, container.ResolveKeyed<ICommmandStorage>(typeof(CommandGetStorageState)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            ICommand command = dictCommands[numberOfRequest];
            command.Execute(rq);
        }
    }
}
