using Project.Domain.QueryFilters;
using System;

namespace Project.Infra.Data.Interfaces
{
    public interface IUriService
    {
        Uri GetVehiculoPaginationUri(VehiculoQueryFilter filter, string actionUrl);
        Uri GetCombustiblePaginationUri(CombustibleQueryFilter filter, string actionUrl);
        Uri GetMarcaPaginationUri(MarcaQueryFilter filter, string actionUrl);
        Uri GetTipoVehiculoPaginationUri(TipoVehiculoQueryFilter filter, string actionUrl);
        Uri GetTransmisionPaginationUri(TransmisionQueryFilter filter, string actionUrl);
    }
}
