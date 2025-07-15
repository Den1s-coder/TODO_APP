using TODO_APP.Core.Model;
using TODO_APP.Core.Model.Requests;

namespace TODO_APP.Data.Repos.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetByIdAsync(int id);
        Task<IEnumerable<User>> GetAllAsync();
        Task Register(RegisterRequest request);
        Task<User> Login(LoginRequest request);
    }
}