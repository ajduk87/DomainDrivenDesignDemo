using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Services.Interfaces
{
    public interface ITruckService
    {
        void Insert(Truck truck);
        void Send(TruckId truckId);
        void Delivered(TruckId truckId);
    }
}
