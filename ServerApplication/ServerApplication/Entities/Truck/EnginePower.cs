using ServerApplication.Entities.ValueObjects.Truck;

namespace ServerApplication.Entities.Truck
{
    public class EnginePower : Entity
    {
        public int Value { get; set; }
        public PowerUnit PowerUnit { get; set; }
    }
}
