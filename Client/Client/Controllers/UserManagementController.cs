using Client.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Application.Interfaces.Services;
namespace Client.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfirmationReminder()
        {
            return View("ConfirmationReminder");
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpViewModel signUpViewModel)
        {
            await _userManagementService.SignUp(signUpViewModel.Name, signUpViewModel.Surname, signUpViewModel.UserName,
                                                signUpViewModel.Password, signUpViewModel.Email, signUpViewModel.Roles);

            return Ok();
        }

        [HttpPost]
        [ActionName("SignIn")]
        public async Task<IActionResult> SignIn(SignInViewModel signInViewModel)
        {
            var token = await _userManagementService.LoginAsync(signInViewModel.UserName, signInViewModel.Password);

            return RedirectToAction("ConfirmationReminder");
        }
    }
}