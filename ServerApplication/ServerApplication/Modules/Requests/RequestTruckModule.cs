using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using ServerApplication.Requests;
using ServerApplication.Requests.Trucks;

namespace ServerApplication.Modules.Requests
{
    public class RequestTruckModule : Module
    {
        protected override void Load(ContainerBuilder objContainer)
        {
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck1));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck2));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck3));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck4));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck5));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck6));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck7));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck8));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck9));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestInsertNewTruck10));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestSendingTruck));
            objContainer.RegisterType<IRequestTruck>().Keyed<IRequest>(typeof(RequestDeliveredProductsByTruck));
            base.Load(objContainer);
        }
    }
}
