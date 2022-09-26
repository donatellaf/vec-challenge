using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    public partial class Combustible : Entity
    {
        public Combustible()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string Name { get; set; }
              
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
