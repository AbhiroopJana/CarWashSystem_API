using CarWashApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class UserProfileRepository : IRepository<UserProfile, int>  
    {
        CarWashContext _context;
        public UserProfileRepository(CarWashContext context) => _context = context;  ///Constructor Injection


        #region CreateUser
        /// <summary>
        /// this method is used to register User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> CreateAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Add(userProfile);   //i will add the user profile in db which i am getting from user 
            await _context.SaveChangesAsync();
            var response = StatusCodes.Status201Created;
            return response;

        }
        #endregion

        #region DeleteUser
        /// <summary>
        /// this method is used to Delete User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> DeleteAsync(UserProfile userProfile)
        {
            _context.UserProfiles.Remove(userProfile);
            await _context.SaveChangesAsync();
            var response = StatusCodes.Status200OK;
            return response;
        }
        #endregion

        #region UserExists
        /// <summary>
        /// this method is used to check if User exists
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public bool Exists(int id)
        {
            return (_context.UserProfiles?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
        #endregion

        #region GetById
        /// <summary>
        /// this method is used to get user by id
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<UserProfile> GetIdAsync(int id)
        {

            return await _context.UserProfiles
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.UserId == id);
        }
        #endregion

        #region UpdateUser
        /// <summary>
        /// this method is used to Update User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> UpdateAsync(UserProfile item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            var response = StatusCodes.Status200OK;
            return response;

        }
        #endregion


        //Ienumerable - base interface for all non-generic collections that can be enumerated
        public async Task<IEnumerable<UserProfile>> GetAsync()
        {
            return await _context.UserProfiles.AsNoTracking().ToListAsync();
        }

    }
}