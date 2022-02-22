using System;
using System.Collections.Generic;

namespace DataMailClient.Model
{
    public class CoreMail
    {
        public Guid Id { get; set; }
        //Doc : https://docs.microsoft.com/fr-fr/dotnet/api/system.guid.newguid?view=net-6.0
        
        public Metadata Metadata { get; set; }

        public string Content { get; set; }

        public Guid History { get; set; }

        public List<Extention> Extensions { get; set; }

        public CoreMail(Guid id, Metadata metadata, string content, 
            Guid history, List<Extention> extensions = null)
        {
            Id = id;
            Metadata = metadata;
            Content = content;
            History = history;
            
            if(Extensions != null)
                Extensions = extensions;
            else
                Extensions = new List<Extention>();
        }

        public CoreMail(Guid id, Metadata metadata, string content,
            List<Extention> extensions = null)
        {
            Id = id;
            Metadata = metadata;
            Content = content;
            History = Guid.Empty;

            if (Extensions != null)
                Extensions = extensions;
            else
                Extensions = new List<Extention>();
        }
    }
}
