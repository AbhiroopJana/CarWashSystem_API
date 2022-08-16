using CarWashApi.DTOs;
using CarWashApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class RegisterRepository:IRegisterRepository<CreateUserDto, UserProfile>
    {
        CarWashContext _context;
        public RegisterRepository(CarWashContext context) => _context = context;

        #region RegisterUser
        /// <summary>
        /// this method is used to register User
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<ActionResult<UserProfile>> CreateAsync(CreateUserDto userProfileDto)
        {
            try
            {

                using var hmac = new HMACSHA512();
                var user = new UserProfile
                {
                    UserName = userProfileDto.UserName,
                    UserEmail = userProfileDto.UserEmail,
                    UserPhnumber = userProfileDto.UserPhnumber,
                    Role = userProfileDto.Role,
                    UserStatus= userProfileDto.UserStatus,
                    UserPassword = userProfileDto.UserPassword,
                    UserPasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userProfileDto.UserPassword)),
                    UserPasswordSalt = hmac.Key
                };

                _context.UserProfiles.Add(user);
                await _context.SaveChangesAsync();
                return user;
            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }


        }

        public bool UserExists(CreateUserDto item)
        {
            return (_context.UserProfiles?.Any(e => e.UserEmail == item.UserEmail)).GetValueOrDefault();
        }
        #endregion
    }
}