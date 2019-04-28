using Autofac;
using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.Services.Interfaces;
using System;

namespace ServerApplication.Commands.Trucks
{
    public class CommandSendingTruck : ICommandTruck
    {
        private IContainer container;
        private HelperClass helperClass;

        public CommandSendingTruck(IContainer container)
        {
            helperClass = new HelperClass();

            this.container = container;
        }

        public void Execute(Request rq) => RequestForSendingTruck(rq);

        private void RequestForSendingTruck(Request rq)
        {
            string truckIdContent = rq.Args[0];

            ITruckService truckService = container.Resolve<ITruckService>();
            TruckId truckId = new TruckId(Convert.ToInt32(truckIdContent));
            truckService.Send(truckId);
        }
    }
}
