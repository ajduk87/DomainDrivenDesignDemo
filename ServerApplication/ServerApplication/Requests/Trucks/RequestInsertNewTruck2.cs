using Autofac;
using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Requests.Trucks
{
    public class RequestInsertNewTruck2 : IRequestTruck
    {
        private IContainer container;
        private HelperClass helperClass;

        public RequestInsertNewTruck2(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForInsertNewTruck2(rq);

        private void RequestForInsertNewTruck2(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId(Convert.ToInt32(trailerIdContent));
            WheelsId wheelsId = new WheelsId(Convert.ToInt32(wheelsIdContent));
            EngineId engineId = new EngineId(Convert.ToInt32(engineIdContent));
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }
    }
}
