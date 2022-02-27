using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataMailClient.Model
{
    public class CoreMail
    {
        [JsonProperty("_id")]
        public Guid _Id { get; set; }
        //Doc : https://docs.microsoft.com/fr-fr/dotnet/api/system.guid.newguid?view=net-6.0
        
        public Metadata Metadata { get; set; }

        public string Content { get; set; }

        public Guid History { get; set; }

        public List<Extention> Extensions { get; set; }

        [JsonConstructor]
        public CoreMail(Guid id, Metadata metadata, string content,
            Guid history, List<Extention> extensions = null)
        {
            _Id = id;
            Metadata = metadata;
            Content = content;

            if(history != null)
                History = history;
            else
                History = Guid.Empty;

            if (extensions != null)
                Extensions = extensions;
            else
                Extensions = new List<Extention>();
        }
    }
}
