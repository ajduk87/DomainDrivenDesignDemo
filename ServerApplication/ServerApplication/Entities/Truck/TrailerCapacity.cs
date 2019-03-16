using ServerApplication.Entities.ValueObjects.Truck;

namespace ServerApplication.Entities.Truck
{
    public class TrailerCapacity : Entity
    {
        public double Value { get; set; }
        public WeightUnit WeightUnit { get; set; }
    }
}
