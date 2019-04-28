using Autofac;
using ServerApplication.Requests.StorageItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Requests.Callers
{
    public class RequestStorageItemCaller
    {
        private IContainer container;
        private Dictionary<long, IRequestStorageItem> dictRequests;

        public RequestStorageItemCaller(IContainer container)
        {
            this.container = container;

            dictRequests = new Dictionary<long, IRequestStorageItem>();
            dictRequests.Add(11, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct1)));
            dictRequests.Add(12, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct2)));
            dictRequests.Add(13, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct3)));
            dictRequests.Add(14, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct4)));
            dictRequests.Add(15, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct5)));
            dictRequests.Add(16, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct6)));
            dictRequests.Add(17, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct7)));
            dictRequests.Add(18, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct8)));
            dictRequests.Add(19, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct9)));
            dictRequests.Add(20, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCreateNewProduct10)));
            dictRequests.Add(25, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestGetProductInfo)));
            dictRequests.Add(26, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestCheckIsProductExists)));
            dictRequests.Add(40, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestUpdateProduct)));
            dictRequests.Add(41, container.ResolveKeyed<IRequestStorageItem>(typeof(RequestDeleteProductFromStorage)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            IRequest Request = dictRequests[numberOfRequest];
            Request.Execute(rq);
        }
    }
}
