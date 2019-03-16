using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class LengthUnit : ValueObject<LengthUnit>
    {
        public string Content { get; set; }
    }
}
