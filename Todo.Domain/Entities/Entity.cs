using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Todo.Domain.Entities {
    //não dá pra ser instanciada - abstract
    //ela é a classe base, outras usarão e n faz sentido ser instanciada

    public abstract class Entity : IEquatable<Entity>
        {
        public Guid Id { get; private set; }
        public Entity (Guid id) {
            Id = Guid.NewGuid();
        }

        public bool Equals(Entity other) {
            return Id == other.Id;

        }
    }
}
