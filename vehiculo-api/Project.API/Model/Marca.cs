using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.API.Model
{
    public partial class Marca
    {
        public Marca()
        {
            Vehiculo = new HashSet<Vehiculo>();
        }

        [Key]
        public int IdMarca { get; set; }
        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [InverseProperty("IdMarcaNavigation")]
        public virtual ICollection<Vehiculo> Vehiculo { get; set; }
    }
}
