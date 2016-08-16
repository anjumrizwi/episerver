using System;
using System.Net.Mail;
using System.Text;
using System.Web.Mvc;

namespace EPiServerDemoSite.Controllers
{
    public class EmailSenderController : Controller
    {
        public static void Send(MailMessage msg)
        {

            try
            {
                using (var smtpClient = new SmtpClient { DeliveryMethod = SmtpDeliveryMethod.Network })
                {
                    smtpClient.Send(msg);
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public static void SendEmail(string ToAddress, string subject, string body, string txtPhone, string txtEmail, string txtName)
        {
            var msg = new MailMessage();
            msg.To.Add(new MailAddress(ToAddress));

            msg.Subject = subject;
            StringBuilder sbInterest = new StringBuilder();
            sbInterest.Append("<b>You have got an enquiry from:</b> <br/> ");
            sbInterest.Append("<b>Name :</b> " + txtName + "<br/>");
            sbInterest.Append("<b>Email :</b> " + txtEmail + "<br/>");
            sbInterest.Append("<b>Phone :</b> " + txtPhone + "<br/>");
            sbInterest.Append("<b>Query :</b> " + body);
            msg.Body = sbInterest.ToString();
            msg.IsBodyHtml = true;
            msg.From = new MailAddress("mailapp@valtech.co.in");
            EmailSenderController.Send(msg);
        }
	}
}