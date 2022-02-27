using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace DataMailClient.Model
{
    public class HomeModel
    {
        public List<CoreMail> CoreMailList{ get; set; }

        public HomeModel()
        {
            CoreMailList = new List<CoreMail>();
        }
    }
}
