using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class ViewCustomersRepository : IViewCustomersRepository
    {
        CarWashContext _context;
        public ViewCustomersRepository(CarWashContext context) => _context = context;


        #region View Customers
        /// <summary>
        /// this method is used to View Customers from User Profiles table
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Customer> ViewCustomersAsync()
        {
            try
            {
                var query = (from a in _context.UserProfiles
                             where a.Role == "Customer"

                             select new Customer()
                             {
                                 UserId = a.UserId,
                                 UserName = a.UserName,
                                 UserPhnumber = a.UserPhnumber,
                                 UserEmail = a.UserEmail,
                                 UserStatus = a.UserStatus
                             });

                List<Customer> list1 = query.ToList();
                return list1;
            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at ViewCustomers in ViewCustomersRepo");
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
                throw;
            }
            finally
            {

            }
        }
        #endregion
    }
}
