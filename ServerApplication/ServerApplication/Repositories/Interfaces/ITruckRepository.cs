using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.RepositoryFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Repositories.Interfaces
{
    public interface ITruckRepository : IRepository
    {
        void Insert(Truck truck);
        void UpdateStatus(TruckId truckId, TruckStatus truckStatus);
        Trailer SelectTrailerByTrailerId(TrailerId trailerId);
        Wheels SelectWheelsByWheelsId(WheelsId wheelsId);
        Engine SelectEnginesByEngineId(EngineId engineId);
    }
}
