using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAsync();  //to get all users
        Task<TEntity> GetIdAsync(TKey id);  //get user by id
        Task<int> CreateAsync(TEntity item);  //to create user
        Task<int> UpdateAsync(TEntity item);  //to update user
        Task<int> DeleteAsync(TEntity item);  //to delete user
        bool Exists(TKey id); // to check user exists or not by id
    }
}
