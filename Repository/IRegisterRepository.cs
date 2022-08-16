using CarWashApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public interface IRegisterRepository<TEntity, TKey> where TEntity : class
    {
        Task<ActionResult<UserProfile>> CreateAsync(TEntity item);
        bool UserExists(TEntity item);
    }
}
