using DataMailClient.Model;
using DataMailClient.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataMailClient
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // POUR TEST
            var mail1 = JSONService.ParseFromJSON(new string(@"Mails/Mail1.json"));
            var json1 = JSONService.SerializeToJSON(mail1);
            var mail2 = JSONService.ParseFromJSON(new string(@"Mails/Mail2.json"));
            var json2 = JSONService.SerializeToJSON(mail1);
            var mail3 = JSONService.ParseFromJSON(new string(@"Mails/Mail3.json"));
            var json3 = JSONService.SerializeToJSON(mail1);
            var mail4 = JSONService.ParseFromJSON(new string(@"Mails/Mail4.json"));
            var json4 = JSONService.SerializeToJSON(mail1);
            var mail5 = JSONService.ParseFromJSON(new string(@"Mails/Mail5.json"));
            var json5 = JSONService.SerializeToJSON(mail1);
            var mail6 = JSONService.ParseFromJSON(new string(@"Mails/Mail6.json"));
            var json6 = JSONService.SerializeToJSON(mail1);

            var mail0to1 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_1.json"));
            var json0to1 = JSONService.SerializeToJSON(mail1);
            var mail0to3 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_3.json"));
            var json0to3 = JSONService.SerializeToJSON(mail1);
            var mail0to5 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_5.json"));
            var json0to5 = JSONService.SerializeToJSON(mail1);
            var mail0to6 = JSONService.ParseFromJSON(new string(@"Mails/Mail0_to_6.json"));
            var json0to6 = JSONService.SerializeToJSON(mail1);
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
