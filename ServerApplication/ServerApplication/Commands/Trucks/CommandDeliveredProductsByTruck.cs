using Autofac;
using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Commands.Trucks
{
    public class CommandDeliveredProductsByTruck : ICommandTruck
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandDeliveredProductsByTruck(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForDeliveredProductsByTruck(rq);

        private void RequestForDeliveredProductsByTruck(Request rq)
        {
            string truckIdContent = rq.Args[0];

            ITruckService truckService = container.Resolve<ITruckService>();
            TruckId truckId = new TruckId { Content = Convert.ToInt32(truckIdContent) };
            truckService.Delivered(truckId);
        }
    }
}
