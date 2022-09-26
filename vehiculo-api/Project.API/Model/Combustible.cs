using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.API.Model
{
    public partial class Combustible
    {
        public Combustible()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public int IdCombustible { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("IdCombustibleNavigation")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
