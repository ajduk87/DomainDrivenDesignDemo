using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Requests.Storages;

namespace ServerApplication.Requests.Callers
{
    public class RequestStorageCaller
    {
        private IContainer container;
        private Dictionary<long, IRequestStorage> dictRequests;

        public RequestStorageCaller(IContainer container)
        {
            this.container = container;

            dictRequests = new Dictionary<long, IRequestStorage>();
            dictRequests.Add(1, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage1)));
            dictRequests.Add(2, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage2)));
            dictRequests.Add(3, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage3)));
            dictRequests.Add(4, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage4)));
            dictRequests.Add(5, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage5)));
            dictRequests.Add(6, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage6)));
            dictRequests.Add(7, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage7)));
            dictRequests.Add(8, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage8)));
            dictRequests.Add(9, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage9)));
            dictRequests.Add(10, container.ResolveKeyed<IRequestStorage>(typeof(RequestCreateNewStorage10)));
            dictRequests.Add(21, container.ResolveKeyed<IRequestStorage>(typeof(RequestGetAllStoragesInfo)));
            dictRequests.Add(23, container.ResolveKeyed<IRequestStorage>(typeof(RequestEnterInSpecificStorage)));
            dictRequests.Add(24, container.ResolveKeyed<IRequestStorage>(typeof(RequestGetStorageState)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            IRequest Request = dictRequests[numberOfRequest];
            Request.Execute(rq);
        }
    }
}
