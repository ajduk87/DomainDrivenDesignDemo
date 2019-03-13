﻿using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities
{
    public class Discount : Entity
    {
        public double Value { get; set; }
        public Percentage Percentage { get; set; }
    }
}
