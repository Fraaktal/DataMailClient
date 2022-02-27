using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataMailClient.Model;
using DataMailClient.Control;
using Microsoft.AspNetCore.Mvc;

namespace DataMailClient
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var homeModel = new HomeModel();

            return View("/Views/Index.cshtml", homeModel);
        }

        public ActionResult MailsInBox(string account)
        {
            var homeResult = new HomeModel();
            var mailController = new MailController();
            homeResult.CoreMailList = mailController.GetMailsInInBox(account);

            return View("~/Views/MailList.cshtml", homeResult);
        }

        public ActionResult MailsOutBox(string account)
        {
            var homeResult = new HomeModel();
            var mailController = new MailController();
            homeResult.CoreMailList = mailController.GetMailsInOutBox(account);

            return View("~/Views/MailList.cshtml", homeResult);
        }

        public ActionResult SendMails
            (
            Guid id, string content, Guid history, string receiver, 
            string subject, string categories, DateTime date,
            string name, string lastName, string account, string mail
            )
        {
            var sender = new Sender(name, lastName, account, mail);
            List<string> categoriesList = categories.Split(',').ToList();
            var metadata = new Metadata(sender, receiver, subject, date, categoriesList);
            var coreMail = new CoreMail(id, metadata, content, history);

            var mailController = new MailController();
            
            coreMail.Metadata.Date = DateTime.Today;
            mailController.SendMail(coreMail);

            return View("~/Views/Sendder.cshtml");
        }
    }
}
