using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace AmsApi.DataModel.Helpers
{
    public class EmailNotificationHelper
    {
        public static string EmailNotification(string fromAddress, string toAddress)
        {
            MailMessage message = new MailMessage("gopivinay3012@gmail.com", "vinaykonakanchi568@gmail.com");
            message.Subject = "New request from employee";
            message.Body = "You have request for approval";

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.EnableSsl = true;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            System.Net.NetworkCredential credential = new System.Net.NetworkCredential();
            credential.UserName = "gopivinay3012@gmail.com";
            credential.Password = "yuwvyubsrcgpsefs";
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = credential;

            smtp.Send(message);

            return "Success";
        }
    }
}
