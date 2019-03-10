using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities
{
    public class Storage : Entity
    {
        public NameOfStorage NameOfStorage { get; set; }
        public KindOfStorage KindOfStorage { get; set; }
    }
}
