using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TailwindMvcApp.Models;

namespace TailwindMvcApp.Controllers
{
    public class LoginController : Controller
    {
        [ActionName("Index")]
        public IActionResult LoginIndex()
        {
            return View("LoginIndex");
        }

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> LoginIndex(UserModel user)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName ?? user.Email),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, "User"),
                new(ClaimTypes.Role, "Admin"),
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);

            return Redirect("/");
        }

        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
