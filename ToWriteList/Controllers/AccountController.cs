using Entities.Db;
using Entities.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ToWriteList.Controllers
{
    [EnableCors("MyPolicy")]
    public class AccountController : Controller
    {
        [HttpGet]
        [Route("Account/Register")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Register")]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                using (ToWriteDbContext dbContext = new ToWriteDbContext())
                {
                    User user = await dbContext.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                    Role userRole = await dbContext.Roles.FirstOrDefaultAsync(r => r.Name == "user");

                    if (userRole != null)
                        user.Role = userRole;

                    dbContext.Users.Add(user);
                    await dbContext.SaveChangesAsync();
                    await Authenticate(user);
                }
                return Redirect("/Index/Menu");

            }
            else
            {
                ModelState.AddModelError("", " Invalid login or password");
            }
            return View(model);
        }

        [HttpGet]
        [Route("Account/Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("Account/Login")]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                using (ToWriteDbContext dbContext = new ToWriteDbContext())
                {
                    User user = await dbContext.Users
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                    if (user != null)
                    {
                        await Authenticate(user);
                        return Redirect("/Index/Menu");
                    }
                }

                ModelState.AddModelError("", "Invalid login or password");
            }
            return View(model);
        }

        [Route("Account/LogOut")]
        public async Task<IActionResult> LogOut()
        {
            if (ModelState.IsValid)
            {
                await HttpContext.SignOutAsync();
                return Redirect("/Account/Login");
            }
            return View();
        }

        private async Task Authenticate(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Email),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, user.Role?.Name)
            };

            ClaimsIdentity id = new ClaimsIdentity(claims, "AppCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }
    }
}
