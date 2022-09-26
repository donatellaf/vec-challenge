using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public partial class TipoVehiculo : Entity
    {
        public TipoVehiculo()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        public string Name { get; set; }

        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
