using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.API.Model
{
    public partial class TipoVehiculo
    {
        public TipoVehiculo()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public int IdTipoVehiculo { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("IdTipoVehiculoNavigation")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
