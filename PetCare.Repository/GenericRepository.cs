using Microsoft.EntityFrameworkCore;
using PetCare.Domain.Models;
using PetCare.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PetCare.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class , IEntidade
    {
        private readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// Busca Genérica retornando o primeiro registo com parâmetro genérico
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<TEntity> GetFirstAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbContext.Set<TEntity>()
                        .AsNoTracking()
                        .FirstOrDefaultAsync(predicate);
        }

        /// <summary>
        /// Retorna todos os registros
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public async Task<IList<TEntity>> GetAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if(predicate == null)
                return await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
            else
                return await _dbContext.Set<TEntity>().Where(predicate).AsNoTracking().ToListAsync();
        }

        /// <summary>
        /// Insert Genérico - retornando o Id 
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task<int> InsertAsync(TEntity entity)
        {
            try
            {

                 _dbContext.Set<TEntity>().Add(entity);
                await _dbContext.SaveChangesAsync();

                return entity.Id;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Update Genérico
        /// </summary>
        /// <param name="id"></param>
        /// <param name="entity"></param>
        /// <returns></returns>
        public async Task UpdateAsync(int id, TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Delete Genérico
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task DeleteAsync(int id)
        {
            var entity = await GetFirstAsync(x => x.Id == id);
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}


