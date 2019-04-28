using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Requests;
using ServerApplication.Requests.Storages;

namespace ServerApplication.Modules.Requests
{
    public class RequestStorageModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage1));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage2));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage3));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage4));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage5));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage6));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage7));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage8));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage9));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestCreateNewStorage10));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestEnterInSpecificStorage));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestGetAllStoragesInfo));
            objContainer.RegisterType<IRequestStorage>().Keyed<IRequestStorage>(typeof(RequestGetStorageState));
            base.Load(objContainer);
        }
    }
}
