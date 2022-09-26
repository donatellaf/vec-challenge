using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.API.Model
{
    public partial class Transmision
    {
        public Transmision()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public int IdTransmision { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("IdTransmisionNavigation")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
