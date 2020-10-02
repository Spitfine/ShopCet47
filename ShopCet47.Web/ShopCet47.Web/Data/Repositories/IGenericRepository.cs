using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        // Interface para ir buscar todos os valores a DB de uma forma generica, serve para qualquer situação com uma base de dados.
        IQueryable<T> GetAll();

        Task<T> GetByIdAsync(int Id);

        Task CreateAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(T entity);

        Task<bool> ExistAsync(int Id);

    }
}
