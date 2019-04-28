using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class LengthUnit
    {
        public string Content { get; }

        public LengthUnit(string Content)
        {
            this.Content = Content;
        }
    }
}
