using Project.Domain.CustomEntitites;
using Project.Domain.Entities;
using Project.Domain.QueryFilters;
using System.Threading.Tasks;

namespace Project.Domain.Interfaces.Services
{
    public interface ICombustibleService
    {
        PagedList<Combustible> GetAllCombustibles(CombustibleQueryFilter filters);

        Task<Combustible> GetCombustible(int id);

        Task InsertCombustible(Combustible combustible);

        Task<bool> UpdateCombustible(Combustible combustible);

        Task<bool> DeleteCombustible(int id);
    }
}
