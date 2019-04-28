using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects.Truck;
using ServerApplication.FactoryFolder;
using ServerApplication.Repositories.Interfaces;
using ServerApplication.RepositoryFactoryFolder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.Truck
{
    public class Truck : Entity
    {
        private ITruckRepository truckRepository;

        public Truck(TrailerId trailerId, WheelsId wheelsId, EngineId engineId, TruckStatus truckStatus)
        {
            this.truckRepository = (ITruckRepository)RepositoryFactory.Create(EntityTypes.Truck);
            Trailer = this.truckRepository.SelectTrailerByTrailerId(trailerId);
            Wheels = this.truckRepository.SelectWheelsByWheelsId(wheelsId);
            Engine = this.truckRepository.SelectEnginesByEngineId(engineId);
            StatusId = new StatusId((int)truckStatus);
        }


        public TruckId TruckId { get; set; }
        public Trailer Trailer { get; set; }
        public Wheels Wheels { get; set; }
        public Engine Engine { get; set; }
        public StatusId StatusId { get; set; }

    }
}
