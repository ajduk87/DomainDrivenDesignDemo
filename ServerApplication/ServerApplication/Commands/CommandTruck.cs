using Autofac;
using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Commands
{
    public class CommandTruck : ICommand
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandTruck(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(long numberOfRequest, Request rq)
        {
            switch (numberOfRequest)
            {
                case 42: RequestForInsertNewTruck1(rq); break;
                case 43: RequestForInsertNewTruck2(rq); break;
                case 44: RequestForInsertNewTruck3(rq); break;
                case 45: RequestForInsertNewTruck4(rq); break;
                case 46: RequestForInsertNewTruck5(rq); break;
                case 47: RequestForInsertNewTruck6(rq); break;
                case 48: RequestForInsertNewTruck7(rq); break;
                case 49: RequestForInsertNewTruck8(rq); break;
                case 50: RequestForInsertNewTruck9(rq); break;
                case 51: RequestForInsertNewTruck10(rq); break;
                case 52: RequestForSendingTruck(rq); break;
                case 53: RequestForDeliveredProductsByTruck(rq); break;
            }
        }

        private void RequestForInsertNewTruck1(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck2(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck3(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck4(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck5(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck6(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck7(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck8(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck9(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForInsertNewTruck10(Request rq)
        {
            string trailerIdContent = rq.Args[0];
            string wheelsIdContent = rq.Args[1];
            string engineIdContent = rq.Args[2];

            ITruckService truckService = container.Resolve<ITruckService>();
            TrailerId trailerId = new TrailerId { Content = Convert.ToInt32(trailerIdContent) };
            WheelsId wheelsId = new WheelsId { Content = Convert.ToInt32(wheelsIdContent) };
            EngineId engineId = new EngineId { Content = Convert.ToInt32(engineIdContent) };
            Truck truck = new Truck(trailerId, wheelsId, engineId, TruckStatus.Available);
            truckService.Insert(truck);
        }

        private void RequestForSendingTruck(Request rq)
        {
            string truckIdContent = rq.Args[0];

            ITruckService truckService = container.Resolve<ITruckService>();
            TruckId truckId = new TruckId { Content = Convert.ToInt32(truckIdContent) };
            truckService.Send(truckId);
        }

        private void RequestForDeliveredProductsByTruck(Request rq)
        {
            string truckIdContent = rq.Args[0];

            ITruckService truckService = container.Resolve<ITruckService>();
            TruckId truckId = new TruckId { Content = Convert.ToInt32(truckIdContent) };
            truckService.Delivered(truckId);
        }
    }
}
