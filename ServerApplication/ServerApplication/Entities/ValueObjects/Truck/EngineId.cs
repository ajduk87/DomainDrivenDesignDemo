using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class EngineId : ValueObject<EngineId>
    {
        public int Content { get; set; }
    }
}
