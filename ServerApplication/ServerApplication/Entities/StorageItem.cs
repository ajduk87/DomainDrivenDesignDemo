using ServerApplication.Entities.Products;
using ServerApplication.Entities.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities
{
    public class StorageItem : Entity
    {
        public NameOfStorage NameOfStorage { get; set; }
        public NameOfProduct NameOfProduct { get; set; }
        public int CountOfProduct { get; set; }
    }
}
