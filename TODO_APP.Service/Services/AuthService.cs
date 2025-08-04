using TODO_APP.Service.DTO;
using TODO_APP.Service.Interfaces;
using Microsoft.AspNetCore.Identity;
using TODO_APP.Core.Model;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using AutoMapper;

namespace TODO_APP.Service.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IMapper _mapper;

        public AuthService(UserManager<User> userManager, SignInManager<User> signInManager, IHttpContextAccessor contextAccessor, IMapper mapper)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _contextAccessor = contextAccessor;
            _mapper = mapper;
        }
        public async Task<UserDto> GetCurrentUserAsync()
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (user == null || !user.IsActive)
            {
                return null;
            }

            return new UserDto
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
            };
        }

        public async Task<bool> IsAuthenticatedAsync()
        {
            var user = await GetCurrentUserAsync();
            return user != null;
        }

        public async Task<bool> IsInRoleAsync(string role)
        {
            var user = await _userManager.GetUserAsync(_contextAccessor.HttpContext.User);
            if (user == null)
            {
                return false;
            }

            return await _userManager.IsInRoleAsync(user, role);
        }

        public async Task<UserDto> LoginAsync(LoginDto loginDto)
        {
            if (string.IsNullOrEmpty(loginDto.Email) || string.IsNullOrEmpty(loginDto.password)) 
            {
                throw new ArgumentException("Email and password are required.");
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null) 
            {
                throw new ArgumentException("Invalid email.");
            }

            if (!user.IsActive) 
            {
                throw new ArgumentException("Account deactivated.");
            }

            var result = await _signInManager.PasswordSignInAsync(user, loginDto.password,loginDto.RememberMe, lockoutOnFailure: false);
            if (!result.Succeeded) 
            {
                throw new ArgumentException("Invalid password.");
            }

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return true;
        }

        public async Task<UserDto> RegisterAsync(RegisterDto registerDto)
        {
            if (string.IsNullOrEmpty(registerDto.Name) || string.IsNullOrEmpty(registerDto.Email) || string.IsNullOrEmpty(registerDto.Password))
            {
                throw new ArgumentException("All fields are required.");
            }

            if (registerDto.Password != registerDto.ConfirmPassword)
            {
                throw new ArgumentException("Passwords do not match.");
            }

            if (registerDto.Password.Length < 6)
            {
                throw new ArgumentException("Password must contain at least 6 characters.");
            }

            var existingUser = await _userManager.FindByEmailAsync(registerDto.Email);
            if (existingUser != null)
            {
                throw new ArgumentException("A user with this email already exists.");
            }

            var user = new User(registerDto.Name,registerDto.Email);
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded) 
            {
                var errors = string.Join(",", result.Errors.Select(e => e.Description));
                throw new ArgumentException($"Register error: {errors}");
            }

            return _mapper.Map<UserDto>(user);
        }
    }
}