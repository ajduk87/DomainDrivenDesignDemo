using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects.Truck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.Truck
{
    public class Trailer : Entity
    {
        public TrailerId  Id { get; set; }
        public TrailerCapacity Capacity { get; set; }
    }
}
