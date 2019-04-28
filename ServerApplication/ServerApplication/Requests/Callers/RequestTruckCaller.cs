using Autofac;
using ServerApplication.Requests.Trucks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Requests.Callers
{
    public class RequestTruckCaller
    {
        private IContainer container;
        private Dictionary<long, IRequestTruck> dictRequests;

        public RequestTruckCaller(IContainer container)
        {
            this.container = container;

            dictRequests = new Dictionary<long, IRequestTruck>();
            dictRequests.Add(42, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck1)));
            dictRequests.Add(43, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck2)));
            dictRequests.Add(44, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck3)));
            dictRequests.Add(45, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck4)));
            dictRequests.Add(46, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck5)));
            dictRequests.Add(47, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck6)));
            dictRequests.Add(48, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck7)));
            dictRequests.Add(49, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck8)));
            dictRequests.Add(50, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck9)));
            dictRequests.Add(51, container.ResolveKeyed<IRequestTruck>(typeof(RequestInsertNewTruck10)));
            dictRequests.Add(52, container.ResolveKeyed<IRequestTruck>(typeof(RequestSendingTruck)));
            dictRequests.Add(53, container.ResolveKeyed<IRequestTruck>(typeof(RequestDeliveredProductsByTruck)));
        }

        public void HandleRequest(long numberOfRequest, Request rq)
        {
            IRequest Request = dictRequests[numberOfRequest];
            Request.Execute(rq);
        }
    }
}
