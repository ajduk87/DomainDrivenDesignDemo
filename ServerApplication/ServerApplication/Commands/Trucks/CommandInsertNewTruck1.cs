using Autofac;
using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands.Trucks
{
    public class CommandInsertNewTruck1 : ICommandTruck
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandInsertNewTruck1(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForInsertNewTruck1(rq);

        private void RequestForInsertNewTruck1(Request rq)
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
