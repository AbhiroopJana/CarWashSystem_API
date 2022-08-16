using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class ViewWashersRepository : IViewWashersRepository
    {
        CarWashContext _context;
        public ViewWashersRepository(CarWashContext context) => _context = context;



        #region View Washers
        /// <summary>
        /// this method is used to View Washers from User Profiles table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Washer> ViewWashersAsync()
        {
            try
            {
                var query = (from a in _context.UserProfiles
                             where a.Role == "Washer"

                             select new Washer()
                             {
                                 WasherId = a.UserId,
                                 WasherName = a.UserName,
                                 WasherPhnumber = a.UserPhnumber,
                                 WasherEmail = a.UserEmail,
                                 WasherStatus = a.UserStatus
                             });
                
                List<Washer> list1 = query.ToList();
                return list1;
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

    }
}
