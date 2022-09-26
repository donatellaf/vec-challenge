namespace Project.Domain.Dtos
{
    public class VehiculoDto
    {
        public int Id { get; set; }
        public string NumeroPatente { get; set; }
        public string NumeroChasis { get; set; }
        public string IdTipoVehiculo { get; set; }
        public string IdMarca { get; set; }
        public string IdCombustible { get; set; }
        public string IdTransmision { get; set; }

        public string TipoVehiculoName { get; set; }
        public string MarcaName { get; set; }
        public string CombustibleName { get; set; }
        public string TransmisionName { get; set; }
        public string ModeloName { get; set; }


    }
}
