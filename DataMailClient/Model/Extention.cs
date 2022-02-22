using System;

namespace DataMailClient.Model
{
    public class Extention
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public string Reference { get ; set; }
        public string Version { get; set; }
        //Format : "XX.xx.xx"

        public Extention(string name, Guid id, string reference, string version)
        {
            Name = name;
            Id = id;
            Reference = reference;
            Version = version;
        }
    }
}
