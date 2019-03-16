using System;
using ServerApplication.Entities.ValueObjects.Truck;

namespace ServerApplication.Entities.Truck
{
    public class WheelsSize : Entity
    {
        public int Value { get; set; }
        public LengthUnit LengthUnit { get; set; }
    }
}
