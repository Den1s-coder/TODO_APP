using TODO_APP.Core.Model;
using TODO_APP.Core.Model.Requests;
using TODO_APP.Data.Repos.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TODO_APP.Data.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly TodoDBContext _context;

        public UserRepository(TodoDBContext context)
        {
            _context = context;
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _context.Users.FindAsync(id) ?? throw new Exception("User not found");
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task Register(RegisterRequest request)
        {
            var user = new User(request.Username, request.Email, request.Password);
            await _context.Users.AddAsync(user);
        }
        //TODO: Implement login logic
        public async Task<User> Login(LoginRequest request)
        {
            return null;
        }
       
    }
}
