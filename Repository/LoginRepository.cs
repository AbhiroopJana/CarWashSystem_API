using CarWashApi.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class LoginRepository : ILoginRepository<Login, int>
    {
        CarWashContext _context;
        public LoginRepository(CarWashContext context) => _context = context;
        
        
        #region Login
        /// <summary>
        /// this method is used to Login
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<int> Login(Login item)
        {
            try
            {
                if (item.Role == "Admin")
                {
                    var user = await _context.Admins
                        .SingleOrDefaultAsync(x => x.AdminEmail == item.Email);
                    if (user == null)
                    {
                        return 404;
                    }
                    else if (user.AdminPassword != item.Password)
                    {
                        return 401;
                    }
                    else
                    {
                        return 200;
                    }


                }
                else
                {
                    var user = await _context.UserProfiles
                        .SingleOrDefaultAsync(x => x.UserEmail == item.Email);

                    if (user == null)
                    {
                        return 404;
                    }
                    else
                    {


                        if (user.Role == item.Role && user.UserStatus == "Active")
                        {
                            using var hmac = new HMACSHA512(user.UserPasswordSalt);

                            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(item.Password));

                            for (int i = 0; i < hash.Length; i++)
                            {
                                if (hash[i] != user.UserPasswordHash[i])
                                {
                                    return 401;
                                }

                            }
                        }
                        else
                        {
                            return 400;
                        }
                    }
                    return 200;
                }

            }
            catch (Exception ex)
            {
                throw;
            }
            finally
            {

            }
        }
        #endregion

        #region getuserId 
        /// <summary>
        /// this method gets user id of the user
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<int> GetUserId(string item)
        {
            try
            {
                var user = await _context.UserProfiles
                         .SingleOrDefaultAsync(x => x.UserEmail == item);
                if (user != null)
                {
                    int userid = user.UserId;
                    return userid;

                }
                else
                {
                    return 404;
                }
            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at GetUserId in Login");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                return 404;
            }
            finally
            {

            }
        }
        #endregion




        #region getUserName 
        /// <summary>
        /// this method gets name of the user
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public async Task<string> GetUserName(string item)
        {
            try
            {
                var user = await _context.UserProfiles
                         .SingleOrDefaultAsync(x => x.UserEmail == item);
                if (user != null)
                {
                    string Username = user.UserName;
                    return Username;

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at GetUserName in Login");
                    writer.WriteLine("Date : " + DateTime.Now.ToString());
                    writer.WriteLine();

                    while (ex != null)
                    {
                        writer.WriteLine(ex.GetType().FullName);
                        writer.WriteLine("Message : " + ex.Message);
                        writer.WriteLine("StackTrace : " + ex.StackTrace);

                        ex = ex.InnerException;
                    }
                }
                return null;
            }
            finally
            {

            }
        }
        #endregion
    }
}
