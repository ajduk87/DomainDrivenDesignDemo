using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class StatusId
    {
        public int Content { get; }

        public StatusId(int Content)
        {
            this.Content = Content;
        }
    }
}
