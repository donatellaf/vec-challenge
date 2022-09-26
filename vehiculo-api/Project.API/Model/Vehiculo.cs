using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.API.Model
{
    public partial class Vehiculo
    {
        [Key]
        public int IdVehiculo { get; set; }
        [Required]
        [StringLength(9)]
        public string NumeroPatente { get; set; }
        [Required]
        [StringLength(17)]
        public string NumeroChasis { get; set; }
        [Required]
        [StringLength(30)]
        public string ModeloName { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int IdMarca { get; set; }
        public int IdCombustible { get; set; }
        public int IdTransmision { get; set; }

        [ForeignKey(nameof(IdCombustible))]
        [InverseProperty(nameof(Combustible.Vehiculo))]
        public virtual Combustible IdCombustibleNavigation { get; set; }
        [ForeignKey(nameof(IdMarca))]
        [InverseProperty(nameof(Marca.Vehiculo))]
        public virtual Marca IdMarcaNavigation { get; set; }
        [ForeignKey(nameof(IdTipoVehiculo))]
        [InverseProperty(nameof(TipoVehiculo.Vehiculo))]
        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
        [ForeignKey(nameof(IdTransmision))]
        [InverseProperty(nameof(Transmision.Vehiculo))]
        public virtual Transmision IdTransmisionNavigation { get; set; }
    }
}
