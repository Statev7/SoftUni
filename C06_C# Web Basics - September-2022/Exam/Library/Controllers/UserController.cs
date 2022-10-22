namespace Library.Controllers
{
    using Library.Data.Models;
    using Library.Models;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [AutoValidateAntiforgeryToken]
    public class UserController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public UserController(
            UserManager<ApplicationUser> userManager, 
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("All", "Books");
            }

            return this.View();
        }

        public async Task<IActionResult> Login(LoginInputModel loginModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(loginModel);
            }

            var user = await this.userManager.FindByNameAsync(loginModel.UserName);
            if (user != null)
            {
                var result = await this.signInManager.PasswordSignInAsync(user, loginModel.Password, false, false);
                if (result.Succeeded)
                {
                    return this.RedirectToAction("All", "Books");
                }
            }

            this.ModelState.AddModelError("", "Invalid user");
            return this.View(loginModel);
        }


        [HttpGet]
        public IActionResult Register()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return this.RedirectToAction("All", "Books");
            }

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(CreateRegisterInputModel registerModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(registerModel);
            }

            var user = new ApplicationUser()
            {
                UserName = registerModel.UserName,
                Email = registerModel.Email,
            };

            var result = await this.userManager.CreateAsync(user, registerModel.Password);
            if (result.Succeeded)
            {
                return this.RedirectToAction(nameof(this.Login));
            }

            foreach (var error in result.Errors)
            {
                this.ModelState.AddModelError("", error.Description);
            }

            return this.View(registerModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await this.signInManager.SignOutAsync();

            return this.RedirectToAction("Index", "Home");
        }

    }
}
