using CarWashApi.Models;
using MimeKit;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarWashApi.Repository
{
    public class PackageRepository :IPackage
    {

        #region SendEmail
        /// <summary>
        /// this method is used to send email for Package adding inimation
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Package> SendEmail(Package package)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse("vtu11310@veltech.edu.in"));
                email.To.Add(MailboxAddress.Parse("sayantanb2000@gmail.com"));
                email.Subject = "Package Added";
                email.Body = new TextPart(MimeKit.Text.TextFormat.Html)
                {
                    Text = "Hi Admin," + "<br>" +
                    "New Package has been added succesfully" + "<br>" +
                    "<pre>                                           Regards, GreenCar Wash.</pre>"
                };
                using var smtp = new MailKit.Net.Smtp.SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, false);
                smtp.Authenticate("vtu11310@veltech.edu.in", "sayan@artpagla");
                smtp.Send(email);
                smtp.Disconnect(true);
                return package;

            }
            catch (Exception ex)
            {
                string filePath = @"E:\Error.txt";
                using (StreamWriter writer = new StreamWriter(filePath, true))
                {
                    writer.WriteLine("-----------------------------------------------------------------------------");
                    writer.WriteLine("Error Caused at SendEmail in PackageRepository");
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

            return package;
        }
        #endregion

    }
}
