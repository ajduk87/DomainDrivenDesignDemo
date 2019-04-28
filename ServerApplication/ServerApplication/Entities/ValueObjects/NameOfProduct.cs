using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities.ValueObjects
{
    public class NameOfProduct : ValueObject<NameOfProduct>
    {
        public string Content { get; set; }

        public NameOfProduct(string Content)
        {
            this.Content = Content;
        }
    }
}
