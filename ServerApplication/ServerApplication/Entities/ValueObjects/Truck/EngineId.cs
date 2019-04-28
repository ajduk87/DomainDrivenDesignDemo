using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class EngineId
    {
        public int Content { get; }

        public EngineId(int Content)
        {
            this.Content = Content;
        }
    }
}
