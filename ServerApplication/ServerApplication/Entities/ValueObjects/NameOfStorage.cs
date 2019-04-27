using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities.ValueObjects
{
    public class NameOfStorage
    {
        public string Content { get; }

        public NameOfStorage(string Content)
        {
            this.Content = Content;
        }
    }
}
