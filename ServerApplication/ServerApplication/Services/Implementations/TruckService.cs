using ServerApplication.Entities.Truck;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.FactoryFolder;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.RepositoryFactoryFolder;
using ServerApplication.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Services.Implementations
{
    public class TruckService : ITruckService
    {
        private ITruckRepository truckRepository;

        public TruckService(TrailerId trailerId, WheelsId wheelsId, EngineId engineId, TruckStatus truckStatus)
        {
            this.truckRepository = (ITruckRepository)RepositoryFactory.Create(EntityTypes.Truck);
        }

        public void Insert(Truck truck)
        {
            this.truckRepository.Insert(truck);
        }

        public void Send(TruckId truckId)
        {
            this.truckRepository.UpdateStatus(truckId, TruckStatus.Unavailable);
        }

        public void Delivered(TruckId truckId)
        {
            this.truckRepository.UpdateStatus(truckId, TruckStatus.Available);
        }
    }
}
