using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Requests;
using ServerApplication.Requests.Storages;
using ServerApplication.Requests.StorageItems;
using ServerApplication.Requests.MoneyValue;

namespace ServerApplication.Modules.Requests
{
    public class RequestMoneyValueModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostAvg));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMax));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostSum));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin1));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin1));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin2));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin3));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin4));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin5));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin6));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin7));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin8));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin9));
            objContainer.RegisterType<IRequestMoneyValue>().Keyed<IRequestStorageItem>(typeof(RequestProductsCostMin10));
            base.Load(objContainer);
        }
    }
}
