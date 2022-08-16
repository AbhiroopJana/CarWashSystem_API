using CarWashApi.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class OrderRepository : IOrderRepository
    {
        #region SendEmail
        /// <summary>
        /// this method is used to send email for order intimation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Order> SendEmail(Order order)
        {
            try
            {
                var toEmail = order.userEmail;
                var email = new MimeMessage();

                var pkgName = order.PkgName;
                var pkgDesc = order.pkgDescription;
                var amount = order.price;
                


                email.From.Add(MailboxAddress.Parse("greencarwash846@gmail.com")); //sender email
                email.To.Add(MailboxAddress.Parse(toEmail));
                email.Subject = "Order Placed";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Hi User," + "<br>" +
                    "Your Order has been placed succesfully" + "<br>" +
                    "Your Package Details: " + "<br>" +
                    "________________________________________________"+
                    "<br>" +
                    "Package Name: " + pkgName + "<br>" +
                    "Package Description: " + pkgDesc + "<br>" +
                    "Total Billing Amount: " + amount + "<br>" +
                    "________________________________________________"+
                    "<br>" +
                    "Regards,"+ "<br>" +
                    "GreenCar Wash."
                };
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("greencarwash846@gmail.com", "ajbuonwsvwnwulew");
                smtp.Send(email);
                smtp.Disconnect(true);
                return order;

            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at SendEmail in OrderRepository");
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
                
            }
            return order;
        }
        #endregion
    }
}
