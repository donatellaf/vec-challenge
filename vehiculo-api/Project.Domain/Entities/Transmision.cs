using System;
using System.Collections.Generic;
namespace Project.Domain.Entities
{
    public partial class Transmision : Entity
    {
        public Transmision()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string Name { get; set; }
              
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
