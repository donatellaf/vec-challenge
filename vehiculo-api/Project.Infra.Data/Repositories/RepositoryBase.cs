using Project.Domain.Entities;
using Project.Domain.Interfaces.Repositories;
using Project.Infra.Data.DbContexts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.Infra.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T : Entity
    {
        private readonly ProjectContext context;
        protected readonly DbSet<T> entities;

        public RepositoryBase(ProjectContext context)
        {
            this.context = context;
            this.entities = context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return entities.AsEnumerable();
        }

        public async Task<T> GetById(int id)
        {
            return await entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await entities.AddAsync(entity);
        }

        public void Update(T entity)
        {
            entities.Update(entity);
        }

        public async Task Delete(int id)
        {
            T entity = await GetById(id);
            entities.Remove(entity);
        }
    }
}
