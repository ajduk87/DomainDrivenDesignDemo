using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities.ValueObjects
{
    public class KindOfStorage : ValueObject<KindOfStorage>
    {
        public string Content { get; set; }

        public KindOfStorage(string Content)
        {
            this.Content = Content;
        }
    }
}
