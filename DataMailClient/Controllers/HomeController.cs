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

        public ActionResult SendMails(CoreMail coreMail)
        {
            var homeResult = new HomeModel();

            return View("~/Views/Sendder.cshtml", homeResult);
        }
    }
}
