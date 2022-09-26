using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Project.Domain.Entities
{
    public abstract class Entity
    {
        
        public virtual int Id { get; set; }
    }
}
