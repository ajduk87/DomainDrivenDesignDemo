using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Commands;
using ServerApplication.Commands.Storages;

namespace ServerApplication.Modules.Commands
{
    public class CommandStorageModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage1));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage2));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage3));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage4));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage5));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage6));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage7));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage8));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage9));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandCreateNewStorage10));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandEnterInSpecificStorage));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandGetAllStoragesInfo));
            objContainer.RegisterType<ICommmandStorage>().Keyed<ICommmandStorage>(typeof(CommandGetStorageState));
            base.Load(objContainer);
        }
    }
}
