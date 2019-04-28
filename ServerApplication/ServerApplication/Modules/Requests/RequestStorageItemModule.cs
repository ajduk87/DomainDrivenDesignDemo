using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Requests;
using ServerApplication.Requests.Storages;
using ServerApplication.Requests.StorageItems;

namespace ServerApplication.Modules.Requests
{
    public class RequestStorageItemModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct1));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct2));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct3));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct4));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct5));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct6));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct7));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct8));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct9));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCreateNewProduct10));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestCheckIsProductExists));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestDeleteProductFromStorage));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestGetProductInfo));
            objContainer.RegisterType<IRequestStorageItem>().Keyed<IRequestStorageItem>(typeof(RequestUpdateProduct));
            base.Load(objContainer);
        }
    }
}
