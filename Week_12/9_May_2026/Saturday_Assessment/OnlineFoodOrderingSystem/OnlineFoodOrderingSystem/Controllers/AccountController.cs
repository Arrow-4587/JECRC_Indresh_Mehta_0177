using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineFoodOrderingSystem.Models;
using OnlineFoodOrderingSystem.ViewModels;

namespace OnlineFoodOrderingSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser>
            _userManager;

        private readonly SignInManager<ApplicationUser>
            _signInManager;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;

            _signInManager = signInManager;
        }

        // =========================
        // REGISTER
        // =========================

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(
            RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email
                };

                var result = await _userManager
                    .CreateAsync(
                        user,
                        model.Password
                    );

                if (result.Succeeded)
                {
                    return RedirectToAction(
                        "Login"
                    );
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        "",
                        error.Description
                    );
                }
            }

            return View(model);
        }

        // =========================
        // LOGIN
        // =========================

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(
            LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(
                        model.Email,
                        model.Password,
                        false,
                        false
                    );

                if (result.Succeeded)
                {
                    return RedirectToAction(
                        "Index",
                        "Food"
                    );
                }

                ModelState.AddModelError(
                    "",
                    "Invalid Login Attempt"
                );
            }

            return View(model);
        }

        // =========================
        // LOGOUT
        // =========================

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction(
                "Login"
            );
        }

        // =========================
        // FORGOT PASSWORD
        // =========================

        public IActionResult ForgotPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ForgotPassword(
            ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager
                    .FindByEmailAsync(model.Email);

                if (user != null)
                {
                    return RedirectToAction(
                        "ResetPassword",
                        new { email = model.Email }
                    );
                }

                ModelState.AddModelError(
                    "",
                    "User not found"
                );
            }

            return View(model);
        }

        // =========================
        // RESET PASSWORD
        // =========================

        public IActionResult ResetPassword(
            string email)
        {
            var model =
                new ResetPasswordViewModel
                {
                    Email = email
                };

            return View(model);
        }

       [HttpPost]
public async Task<IActionResult> ResetPassword(
    ResetPasswordViewModel model)
{
    if (ModelState.IsValid)
    {
        var user = await _userManager
            .FindByEmailAsync(model.Email);

        if (user != null)
        {
            var token = await _userManager
                .GeneratePasswordResetTokenAsync(user);

            var result = await _userManager
                .ResetPasswordAsync(
                    user,
                    token,
                    model.NewPassword
                );

            if (result.Succeeded)
            {
                return RedirectToAction("Login");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(
                    "",
                    error.Description
                );
            }
        }
        else
        {
            ModelState.AddModelError(
                "",
                "User not found"
            );
        }
    }

    return View(model);
}
    }
}