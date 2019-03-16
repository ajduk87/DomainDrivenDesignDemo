using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerApplication.Entities.ValueObjects
{
    public class Percentage : ValueObject<Percentage>
    {
        public string Content { get; set; }
    }
}
