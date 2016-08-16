using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPiServer;
using EPiServer.Core;
using EPiServer.Web;
using EPiServer.Web.Mvc;
using EPiServerDemoSite.Models.Blocks;
using EPiServerDemoSite.Controllers;

namespace EPiServerDemoSite.Controllers
{
    public class ContactUsBlockController : BlockController<ContactusBlock>
    {
        public override ActionResult Index(ContactusBlock currentBlock)
        {
            return PartialView(currentBlock);
        }
        [HttpPost]
        public ActionResult SendMail(string txtName, string txtEmail, string txtPhone, string txtMessage, string Email)
        {
           
            string toEmail = string.IsNullOrEmpty(Email) ? "priya.renjit@gmail.com" : Email;
            EmailSenderController.SendEmail(toEmail, "Query", txtMessage, txtPhone, txtEmail, txtName);
            ViewBag.Message = "ThankYou for conatcting us...we will be in touch with you shorlty!!!";             
            return Content(ViewBag.Message);
        }
    }
}
