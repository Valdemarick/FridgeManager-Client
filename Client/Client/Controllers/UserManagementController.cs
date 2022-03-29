using Client.Models.Users;
using Domain.Common;
using Domain.Interfaces.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Client.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IServiceManager _serviceManager;

        public UserManagementController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult SignUp()
        {
            return View("SignUp", new SignUpViewModel());
        }

        [HttpPost]
        [ActionName(nameof(SignUpPostAsync))]
        public async Task<IActionResult> SignUpPostAsync(SignUpViewModel signUpViewModel)
        {
            if (!ModelState.IsValid)
                return View("SignUp", signUpViewModel);

            await _serviceManager.UserManagementService.SignUp(signUpViewModel.Name, signUpViewModel.Surname, signUpViewModel.UserName,
                                                signUpViewModel.Password, signUpViewModel.Email);

            return RedirectToAction("Index");
        }

        [HttpPost]
        [ActionName(nameof(SignInPostAsync))]
        public async Task<IActionResult> SignInPostAsync(SignInViewModel signInViewModel)
        {
            if (!ModelState.IsValid)
                return View("Index", signInViewModel);

            var token = await _serviceManager.UserManagementService.LoginAsync(signInViewModel.UserName, signInViewModel.Password);

            Response.Cookies.Append(Constants.XAccessToken, token.Token, new CookieOptions()
            {
                HttpOnly = true,
                SameSite = SameSiteMode.Strict
            });

            return RedirectToAction("Index", "Home");
        }
    }
}