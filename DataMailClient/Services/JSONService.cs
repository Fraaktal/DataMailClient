using DataMailClient.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Schema;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json.Serialization;

namespace DataMailClient.Services
{
    public class JSONService
    {
        public static CoreMail ParseFromJSONAndValidate(string path, out IList<string> errors)
        {
            JSchema schema = JSchema.Parse(File.ReadAllText(@"Model/core_mail.schema.json"));
            bool res = ValidatingJSON(schema, path, out errors);
            if (res)
            {
                return ParseFromJSON(path);
            }

            return null;
        }

        public static CoreMail ParseFromJSON(string path)
        {
            return JsonConvert.DeserializeObject<CoreMail>(File.ReadAllText(path));
        }

        public static string SerializeToJSON(CoreMail mail)
        {
            var serializerSettings = new JsonSerializerSettings();
            serializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            return JsonConvert.SerializeObject(mail, Formatting.Indented, serializerSettings);
        }

        public static bool ValidatingJSON(JSchema schema, string path, out IList<string> output)
        {
            JObject obj = JObject.Parse(File.ReadAllText(path));
            bool isValid = obj.IsValid(schema, out output);

            return isValid;
        }
    }
}
