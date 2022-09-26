
using Project.Domain.QueryFilters;
using Project.Infra.Data.Interfaces;
using System;

namespace Project.Infra.Data.Services
{
    public class UriService : IUriService
    {
        private readonly string baseUri;

        public UriService(string baseUri)
        {
            this.baseUri = baseUri;
        }

        public Uri GetVehiculoPaginationUri(VehiculoQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetCombustiblePaginationUri(CombustibleQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetMarcaPaginationUri(MarcaQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetTipoVehiculoPaginationUri(TipoVehiculoQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }

        public Uri GetTransmisionPaginationUri(TransmisionQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }
    }
}
