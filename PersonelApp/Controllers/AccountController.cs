using BLL.Dto;
using BLL.Repo;
using BLL.Services;
using Microsoft.AspNetCore.Mvc;
using PersonelApp.Helpers;
using PersonelApp.Models;

namespace PersonelApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserService _userService;
        private readonly JwtHelper _jwtHelper;

        public AccountController(UserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _jwtHelper = new JwtHelper(configuration);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(UserDto dto)
        {
            if (!ModelState.IsValid) { return View(dto); }

            var user = _userService.Validate(dto.UserName, dto.Password);
            if (user == null) { ModelState.AddModelError("", "Kullanıcı adı veya şifre yanlış"); return View(dto); }

            var token= _jwtHelper.GenerateToken(user);

            Response.Cookies.Append("jwt", token);
            return RedirectToAction("Index", "Home");
        }
        [HttpPost]
        public IActionResult Logout()
        {
            Response.Cookies.Delete("jwt");
            return RedirectToAction("Login");
        }
    }
}
