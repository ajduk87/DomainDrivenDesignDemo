using Autofac;
using ServerApplication.Requests.MoneyValue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Requests.Callers
{
    public class RequestMoneyValueCaller
    {
        private IContainer container;
        private Dictionary<long, IRequestMoneyValue> dictRequests;

        public RequestMoneyValueCaller(IContainer container)
        {
            this.container = container;

            dictRequests = new Dictionary<long, IRequestMoneyValue>();
            dictRequests.Add(27, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin1)));
            dictRequests.Add(28, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin2)));
            dictRequests.Add(29, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin3)));
            dictRequests.Add(30, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin4)));
            dictRequests.Add(31, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin5)));
            dictRequests.Add(32, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin6)));
            dictRequests.Add(33, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin7)));
            dictRequests.Add(34, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin8)));
            dictRequests.Add(35, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin9)));
            dictRequests.Add(36, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMin10)));
            dictRequests.Add(37, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostMax)));
            dictRequests.Add(38, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostAvg)));
            dictRequests.Add(39, container.ResolveKeyed<IRequestMoneyValue>(typeof(RequestProductsCostSum)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            IRequest Request = dictRequests[numberOfRequest];
            Request.Execute(rq);
        }
    }
}
