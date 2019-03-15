using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ServerApplication.Entities
{
    public abstract class Entity
    {
        public virtual Guid Id { get; protected set; }

        public Entity()
        {
            Id = Guid.NewGuid();
        }

        public Entity(Guid? id)
        {
            if (id.HasValue)
            {
                Id = id.Value;
            }
            else
            {
                Id = Guid.NewGuid();
            }
        }
    }
}
