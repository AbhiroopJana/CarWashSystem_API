using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public interface ILoginRepository<TEntity, TKey> where TEntity : class
    {
        Task<int> Login(TEntity item);
        Task<int> GetUserId(string item);

        Task<string> GetUserName(string item);
    }
}
