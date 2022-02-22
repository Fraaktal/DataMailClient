using DataMailClient.Model;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace DataMailClient.Services
{
    public class JSONService
    {
        public static CoreMail ParseFromJSON(string path)
        {
            return JsonConvert.DeserializeObject<CoreMail>(File.ReadAllText(path));
        }

        public static string SerializeToJSON(CoreMail mail)
        {
            return JsonConvert.SerializeObject(mail);
        }
    }
}
