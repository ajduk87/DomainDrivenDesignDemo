﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects.Truck
{
    public class WeightUnit
    {
        public string Content { get; }

        public WeightUnit(string Content)
        {
            this.Content = Content;
        }
    }
}
