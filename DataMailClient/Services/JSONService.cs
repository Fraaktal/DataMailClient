using DataMailClient.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
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

        public static IList<string> ValidatingJSON(JSchema schema, string path)
        {
            IList<string> output;

            JObject obj = JObject.Parse(File.ReadAllText(path));
            obj.IsValid(schema, out output);

            return output;
        }
    }
}
