using DataMailClient.Model;
using DataMailClient.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DataMailClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // POUR TEST
            JSchema schema = JSchema.Parse(File.ReadAllText(@"Model/core_mail.schema.json"));
            List<string> debug = new List<string>();

            var mail1 = JSONService.ParseFromJSON(new string(@"Mails/Mail1.json")); //v�rification de la conversion en object mail
            var json1 = JSONService.SerializeToJSON(mail1); //v�rification du fonctionnement de la s�rialisation
            debug.Add("Mail1");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail1.json")); //v�rification de la conformit�

            var mail2 = JSONService.ParseFromJSON(new string(@"Mails/Mail2.json"));
            var json2 = JSONService.SerializeToJSON(mail2);
            debug.Add("Mail2");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail2.json"));

            var mail3 = JSONService.ParseFromJSON(new string(@"Mails/Mail3.json"));
            var json3 = JSONService.SerializeToJSON(mail3);
            debug.Add("Mail3");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail3.json"));

            var mail4 = JSONService.ParseFromJSON(new string(@"Mails/Mail4.json"));
            var json4 = JSONService.SerializeToJSON(mail4);
            debug.Add("Mail4");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail4.json"));

            var mail5 = JSONService.ParseFromJSON(new string(@"Mails/Mail5.json"));
            var json5 = JSONService.SerializeToJSON(mail5);
            debug.Add("Mail5");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail5.json"));

            var mail6 = JSONService.ParseFromJSON(new string(@"Mails/Mail6.json"));
            var json6 = JSONService.SerializeToJSON(mail6);
            debug.Add("Mail6");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail6.json"));


            var mail0to1 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_1.json"));
            var json0to1 = JSONService.SerializeToJSON(mail0to1);
            debug.Add("Mail0_to_1");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_1.json"));

            var mail0to3 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_3.json"));
            var json0to3 = JSONService.SerializeToJSON(mail0to3);
            debug.Add("Mail0_to_3");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_3.json"));

            var mail0to5 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_5.json"));
            var json0to5 = JSONService.SerializeToJSON(mail0to5);
            debug.Add("Mail0_to_5");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_5.json"));

            var mail0to6 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_6.json"));
            var json0to6 = JSONService.SerializeToJSON(mail0to6);
            debug.Add("Mail0_to_6");
            debug.AddRange(JSONService.ValidatingJSON(schema, @"Mails/Mail0_to_6.json"));
            // FIN TEST 

            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });        
    }
}
