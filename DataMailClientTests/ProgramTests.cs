using System;
using System.Collections.Generic;
using System.IO;
using DataMailClient.Control;
using DataMailClient.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json.Schema;

namespace DataMailClientTests
{
    [TestClass()]
    public class ProgramTests
    {
        string _pathdir = @"C:\Users\trava\OneDrive\Bureau\DATA\Projet2";

        [TestCleanup]
        public void Clean()
        {
            Directory.Delete(_pathdir, true);
        }

        [TestMethod()]
        public void MainTest()
        {
            JSchema schema = JSchema.Parse(File.ReadAllText(@"Model/core_mail.schema.json"));
            List<string> debug = new List<string>();

            var mail1 = JSONService.ParseFromJSON(
                new string(@"Mails/Mail1.json")); //vérification de la conversion en object mail
            var json1 = JSONService.SerializeToJSON(mail1); //vérification du fonctionnement de la sérialisation
            debug.Add("Mail1");
            JSONService.ValidatingJSON(schema, @"Mails/Mail1.json", out var errors);
            debug.AddRange(errors); //vérification de la conformité

            var mail2 = JSONService.ParseFromJSON(new string(@"Mails/Mail2.json"));
            var json2 = JSONService.SerializeToJSON(mail2);
            debug.Add("Mail2");
            JSONService.ValidatingJSON(schema, @"Mails/Mail2.json", out errors);
            debug.AddRange(errors);

            var mail3 = JSONService.ParseFromJSON(new string(@"Mails/Mail3.json"));
            var json3 = JSONService.SerializeToJSON(mail3);
            debug.Add("Mail3");
            JSONService.ValidatingJSON(schema, @"Mails/Mail3.json", out errors);
            debug.AddRange(errors);

            var mail4 = JSONService.ParseFromJSON(new string(@"Mails/Mail4.json"));
            var json4 = JSONService.SerializeToJSON(mail4);
            debug.Add("Mail4");
            JSONService.ValidatingJSON(schema, @"Mails/Mail4.json", out errors);
            debug.AddRange(errors);

            var mail5 = JSONService.ParseFromJSON(new string(@"Mails/Mail5.json"));
            var json5 = JSONService.SerializeToJSON(mail5);
            debug.Add("Mail5");
            JSONService.ValidatingJSON(schema, @"Mails/Mail5.json", out errors);
            debug.AddRange(errors);

            var mail6 = JSONService.ParseFromJSON(new string(@"Mails/Mail6.json"));
            var json6 = JSONService.SerializeToJSON(mail6);
            debug.Add("Mail6");
            JSONService.ValidatingJSON(schema, @"Mails/Mail6.json", out errors);
            debug.AddRange(errors);

            var mail0to1 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_1.json"));
            var json0to1 = JSONService.SerializeToJSON(mail0to1);
            debug.Add("Mail0_to_1");
            JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_1.json", out errors);
            debug.AddRange(errors);

            var mail0to3 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_3.json"));
            var json0to3 = JSONService.SerializeToJSON(mail0to3);
            debug.Add("Mail0_to_3");
            JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_3.json", out errors);
            debug.AddRange(errors);

            var mail0to5 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_5.json"));
            var json0to5 = JSONService.SerializeToJSON(mail0to5);
            debug.Add("Mail0_to_5");
            JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_5.json", out errors);
            debug.AddRange(errors);

            var mail0to6 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_6.json"));
            var json0to6 = JSONService.SerializeToJSON(mail0to6);
            debug.Add("Mail0_to_6");
            JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_6.json", out errors);
            debug.AddRange(errors);


            MailController controller = new MailController(_pathdir);
            controller.SendMail(mail1);
            var resultR = controller.GetMailsInInBox(mail1.Metadata.Receiver);
            var resultS = controller.GetMailsInOutBox(mail1.Metadata.Sender.Mail);

            Assert.AreEqual(10, debug.Count);
            Assert.AreEqual(1, resultR.Count);
            Assert.AreEqual(1, resultS.Count);
        }
    }
}