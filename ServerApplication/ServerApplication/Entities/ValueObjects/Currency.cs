using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities.ValueObjects
{
    public class Currency : ValueObject<Currency>
    {
        public string Content { get; }

        public Currency(string Content)
        {
            this.Content = Content;
        }
    }
}
