namespace Project.Domain.QueryFilters
{
    public class VehiculoQueryFilter
    {
        public string Patente { get; set; }
        public string Chasis { get; set; }
        public int IdTipoVehiculo { get; set; }
        public int IdMarca { get; set; }
        public int IdCombustible { get; set; }
        public int IdTransmision { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
    }
}
