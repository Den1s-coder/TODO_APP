using Microsoft.AspNetCore.Mvc;
using TODO_APP.Service.DTO;
using TODO_APP.Service.Interfaces;

namespace TODO_APP.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDto loginDto, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
            {
                return View(loginDto);
            }

            try
            {
                var user = await _authService.LoginAsync(loginDto);

                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                {
                    return Redirect(returnUrl);
                }

                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(loginDto);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid)
            {
                return View(registerDto);
            }

            try
            {
                var user = await _authService.RegisterAsync(registerDto);

                //Auto login
                var loginDto = new LoginDto
                {
                    Email = registerDto.Email,
                    password = registerDto.Password,
                    RememberMe = false
                };

                await _authService.LoginAsync(loginDto);

                TempData["SuccessMessage"] = "Registration successful! Welcome to TODO App.";
                return RedirectToAction("Index", "Home");
            }
            catch (ArgumentException ex) 
            {
                ModelState.AddModelError("", ex.Message);
                return View(registerDto);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _authService.LogoutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var user = await _authService.GetCurrentUserAsync();
            if (user == null)
            {
                return RedirectToAction("Login");
            }
            return View(user);
        }
    }
}