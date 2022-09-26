using System;
using System.Collections.Generic;

namespace Project.Domain.Entities
{
    public partial class Vehiculo : Entity
    {
        public string NumeroPatente { get; set; }
        public string NumeroChasis { get; set; }
        public string ModeloName { get; set; }
        public int? IdTipoVehiculo { get; set; }
        public int? IdMarca { get; set; }
        public int? IdCombustible { get; set; }
        public int? IdTransmision { get; set; }

        public virtual Marca IdMarcaNavigation { get; set; }
        public virtual TipoVehiculo IdTipoVehiculoNavigation { get; set; }
        public virtual Combustible IdCombustibleNavigation { get; set; }
        public virtual Transmision IdTransmisionNavigation { get; set; }
    }
}
