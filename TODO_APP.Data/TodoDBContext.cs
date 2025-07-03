using Microsoft.EntityFrameworkCore;
using TODO_APP.Core.Model;

namespace TODO_APP.Data
{
    public class TodoDBContext : DbContext
    {
        public TodoDBContext(DbContextOptions<TodoDBContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
