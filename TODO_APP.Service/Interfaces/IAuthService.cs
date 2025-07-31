using TODO_APP.Service.DTO;

namespace TODO_APP.Service.Interfaces
{
    public interface IAuthService
    {
        Task<UserDto> RegisterAsync(RegisterDto registerDto);
        Task<UserDto> LoginAsync(LoginDto loginDto);
        Task<bool> LogoutAsync();
        Task<UserDto> GetCurrentUserAsync();
        Task<bool> IsAuthenticatedAsync();
        Task<bool> IsInRoleAsync(string role);
    }
}
