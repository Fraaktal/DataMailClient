namespace DataMailClient.Model
{
    public class Sender
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Account { get; set; }
        public string Email { get; set; }

        public Sender(string name, string lastName, string account, string email)
        {
            Name = name;
            LastName = lastName;
            Account = account;
            Email = email;
        }
    }
}
