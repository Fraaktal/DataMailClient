using System;
using System.Collections.Generic;
using System.IO;
using DataMailClient.Model;
using DataMailClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace DataMailClient.Control
{
    public class MailController : Controller
    {
        private readonly string _baseDirectory;
        private const string INBOX = "inbox";
        private const string OUTBOX = "outbox";

        public ActionResult Index()
        {
            HomeModel homeModel = new HomeModel();

            return View("/Views/Index.cshtml", homeModel);
        }

        public MailController(string basePath = null)
        {
            if (basePath != null)
            {
                _baseDirectory = basePath;
            }
            else
            {
                _baseDirectory = new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.FullName;
            }
        }

        public void SendMail(CoreMail coreMail)
        {
            CreateFolderIfNeeded(coreMail.Metadata.Sender.Mail);
            CreateFolderIfNeeded(coreMail.Metadata.Receiver);

            var serializedMail = JSONService.SerializeToJSON(coreMail);

            AddMailToOutBox(coreMail.Metadata.Subject, coreMail.Metadata.Sender.Mail, serializedMail);
            SendMailToDestination(coreMail.Metadata.Subject, coreMail.Metadata.Sender.Mail, coreMail.Metadata.Receiver);
        }

        private void CreateFolderIfNeeded(string account)
        {
            var basePath = Path.Combine(_baseDirectory, account);
            if (!Directory.Exists(basePath))
            {
                Directory.CreateDirectory(basePath);
                Directory.CreateDirectory(Path.Combine(basePath, INBOX));
                Directory.CreateDirectory(Path.Combine(basePath, OUTBOX));
            }
        }

        private void AddMailToOutBox(string subject, string account, string mail)
        {
            string path = Path.Combine(_baseDirectory, account, OUTBOX, subject);
            //File.WriteAllText(path, mail);
        }

        private void SendMailToDestination(string subject, string source, string destination)
        {
            string sourcePath = Path.Combine(_baseDirectory, source, OUTBOX, subject);
            string destinationPath = Path.Combine(_baseDirectory, destination, INBOX, subject);
            //File.Copy(sourcePath, destinationPath);
        }

        public ActionResult GetMailsInInBox(string account)
        {
            HomeModel homeResult = new HomeModel();
            CreateFolderIfNeeded(account);

            homeResult.CoreMailList = GetMailsIn(Path.Combine(_baseDirectory, account, INBOX));
            return PartialView("~/Views/GetMailsInInBox.cshtml", homeResult);
        }

        public List<CoreMail> GetMailsInOutBox(string account)
        {
            CreateFolderIfNeeded(account);

            var result = GetMailsIn(Path.Combine(_baseDirectory,account, OUTBOX));
            return result;
        }

        private List<CoreMail> GetMailsIn(string path)
        {
            List<CoreMail> result = new List<CoreMail>();

            var dir = new DirectoryInfo(path);
            if (dir.Exists)
            {
                foreach (var file in dir.GetFiles())
                {
                    var mail = JSONService.ParseFromJSONAndValidate(file.FullName, out var errors);
                    if (mail != null)
                    {
                        result.Add(mail);
                    }
                    else
                    {
                        Console.WriteLine($"Le mail : {file.FullName} n'est pas valide :");
                        foreach (var error in errors){
                            Console.WriteLine(error);
                        }
                    }
                }
            }

            return result;
        }
    }
}
