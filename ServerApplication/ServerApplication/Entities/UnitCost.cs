using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities
{
    public class UnitCost : Entity
    {
        public double Value { get; set; }
        public Currency Currency { get; set; }
    }
}
