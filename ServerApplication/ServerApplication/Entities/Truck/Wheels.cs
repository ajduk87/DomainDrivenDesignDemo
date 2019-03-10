using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects.Truck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.Truck
{
    public class Wheels : Entity
    {
        public WheelsId Id { get; set; }
        public WheelsSize Size { get; set; }
    }
}
