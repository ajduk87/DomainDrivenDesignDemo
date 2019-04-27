using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities.ValueObjects
{
    public class Percentage : ValueObject<Percentage>
    {
        public string Content { get; }

        public Percentage(string Content)
        {
            this.Content = Content;
        }
    }
}
