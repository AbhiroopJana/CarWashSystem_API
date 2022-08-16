using CarWashApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class ViewInvoiceRepository : IViewInvoiceRepository
    {
        CarWashContext _context;

        public ViewInvoiceRepository(CarWashContext context) => _context = context;

        #region View Invoice
        /// <summary>
        /// this method is used to invoice of a particular Customer
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public List<Invoice> ViewInvoiceAsync(string email)
        {
            try
            {
                var query = (from a in _context.Orders
                             where
                             a.userEmail == email

                             select new Invoice()
                             {
                                 PkgName = a.PkgName,
                                 pkgDescription = a.PkgName,
                                 price = a.price,
                                 regNumber = a.regNumber,
                                 address = a.address,
                                 city = a.city,
                                 state = a.state,
                                 pinCode = a.pinCode,
                                 instructions = a.instructions,
                                 date = a.date
                             });


                List<Invoice> list1 = query.ToList();
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
