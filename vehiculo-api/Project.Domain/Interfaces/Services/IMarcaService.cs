using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.QueryFilters;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Services
{
    public interface IMarcaService
    {
        PagedList<Marca> GetAllMarcas(MarcaQueryFilter filters);

        Task<Marca> GetMarca(int id);

        Task InsertMarca(Marca marca);

        Task<bool> UpdateMarca(Marca marca);

        Task<bool> DeleteMarca(int id);
    }
}
