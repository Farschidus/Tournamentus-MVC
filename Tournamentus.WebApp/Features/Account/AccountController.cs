using Tournamentus.Core.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Tournamentus.WebApp.Features.Account
{
    public class AccountController : Controller
    {
        private UserManager<User> _userManager { get; }
        private SignInManager<User> _signInManager { get; }

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IActionResult> Register([FromForm] User model)
        {
            var result = await _userManager.CreateAsync(model);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Result = "result is: " + result.ToString();
            }

            return View();
        }

        public async Task<IActionResult> Login([FromForm] User model)
        {
            var signInResult = await _signInManager.PasswordSignInAsync(model.UserName, "fghj", isPersistent: true, lockoutOnFailure: false);

            if (!signInResult.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username and password combination not recognised.");

                if (signInResult.IsNotAllowed)
                {
                    ModelState.AddModelError(string.Empty, "Login is not allowed for this account.");
                }

                if (signInResult.IsLockedOut)
                {
                    ModelState.AddModelError(string.Empty, "Account is locked.");
                }

                if (signInResult.RequiresTwoFactor)
                {
                    ModelState.AddModelError(string.Empty, "Login requires two factor authentication");
                }
            }

            return View(model);
        }

    }
}
