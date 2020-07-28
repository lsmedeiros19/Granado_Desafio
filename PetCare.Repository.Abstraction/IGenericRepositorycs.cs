using PetCare.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Repository.Abstraction
{
    public interface IGenericRepository<TEntity>
     where TEntity : class, IEntidade
    {
        Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null);

        Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate);

        Task<int> InsertAsync(TEntity entity);

        Task UpdateAsync(int id, TEntity entity);

        Task DeleteAsync(int id);
    }

}



