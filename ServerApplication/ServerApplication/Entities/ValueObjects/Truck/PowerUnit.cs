using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class PowerUnit : ValueObject<PowerUnit>
    {
        public string Content { get; }

        public PowerUnit(string Content)
        {
            this.Content = Content;
        }
    }
}
