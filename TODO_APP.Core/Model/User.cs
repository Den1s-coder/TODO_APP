namespace TODO_APP.Core.Model
{ 
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }

        public User(){} // for EF
        
        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = password;
        }
    }
}
