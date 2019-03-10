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
                case 42: requestForInsertNewTruck1(rq); break;
                case 43: requestForInsertNewTruck2(rq); break;
                case 44: requestForInsertNewTruck3(rq); break;
                case 45: requestForInsertNewTruck4(rq); break;
                case 46: requestForInsertNewTruck5(rq); break;
                case 47: requestForInsertNewTruck6(rq); break;
                case 48: requestForInsertNewTruck7(rq); break;
                case 49: requestForInsertNewTruck8(rq); break;
                case 50: requestForInsertNewTruck9(rq); break;
                case 51: requestForInsertNewTruck10(rq); break;
                case 52: requestForSendingTruck(rq); break;
                case 53: requestForDeliveredProductsByTruck(rq); break;
            }
        }

        private void requestForInsertNewTruck1(Request rq)
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

        private void requestForInsertNewTruck2(Request rq)
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

        private void requestForInsertNewTruck3(Request rq)
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

        private void requestForInsertNewTruck4(Request rq)
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

        private void requestForInsertNewTruck5(Request rq)
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

        private void requestForInsertNewTruck6(Request rq)
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

        private void requestForInsertNewTruck7(Request rq)
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

        private void requestForInsertNewTruck8(Request rq)
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

        private void requestForInsertNewTruck9(Request rq)
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

        private void requestForInsertNewTruck10(Request rq)
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

        private void requestForSendingTruck(Request rq)
        {
            string truckIdContent = rq.Args[0];

            ITruckService truckService = container.Resolve<ITruckService>();
            TruckId truckId = new TruckId { Content = Convert.ToInt32(truckIdContent) };
            truckService.Send(truckId);
        }

        private void requestForDeliveredProductsByTruck(Request rq)
        {
            string truckIdContent = rq.Args[0];

            ITruckService truckService = container.Resolve<ITruckService>();
            TruckId truckId = new TruckId { Content = Convert.ToInt32(truckIdContent) };
            truckService.Delivered(truckId);
        }
    }
}
