using System;
using System.Collections.Generic;

namespace DataMailClient.Model
{
    public class Metadata
    {
        public Sender Sender { get; set; }
        public string Receiver { get; set; }
        public string Subject { get; set; }
        public List<string> Categories { get; set; }
        public DateTime Date { get; set; }
        
        public Metadata(Sender sender, string receiver, string subject,
            DateTime date, List<string> categories = null)
        {
            Sender = sender;
            Receiver = receiver;
            Subject = subject;
            Date = date;

            if(Categories != null)
                Categories = categories;
            else
                Categories = new List<string>();
        }

    }
}
