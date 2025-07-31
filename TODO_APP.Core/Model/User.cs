using Microsoft.AspNetCore.Identity;

namespace TODO_APP.Core.Model
{ 
    public class User:IdentityUser<Guid>
    {
        public string Name { get; set; }
        public string Role { get; set; } = "User";
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public User() { } // for EF

        public User(string name, string email, string password)
        {
            Id = Guid.NewGuid();
            Name = name;
            Email = email;
            PasswordHash = password;
            Role = "User";
            CreatedAt = DateTime.UtcNow;
        }
    }
}
