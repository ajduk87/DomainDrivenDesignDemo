﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class TrailerId
    {
        public int Content { get; }

        public TrailerId(int Content)
        {
            this.Content = Content;
        }
    }
}
