﻿//namespace HospitalPharmacyManagementSystem.Web.Controllers
//{
//    using HospitalPharmacyManagementSystem.Data.Models;
//    using Microsoft.AspNetCore.Authentication;
//    using Microsoft.AspNetCore.Authorization;
//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.AspNetCore.Mvc;
//    using Griesoft.AspNetCore.ReCaptcha;
//    using Microsoft.AspNetCore.Authentication;
//    using Microsoft.AspNetCore.Identity;
//    using Microsoft.AspNetCore.Mvc;

//    using Data.Models;
//    using ViewModels.User;

//    using static Common.NotificationMessages;

//    [Authorize]
//    public class UserController : Controller
//    {
//        private readonly SignInManager<AppUser> signInManager;
//        private readonly UserManager<AppUser> userManager;

//        public UserController(SignInManager<AppUser> signInManager,
//                              UserManager<AppUser> userManager)
//        {
//            this.signInManager = signInManager;
//            this.userManager = userManager;
//        }

//        [HttpGet]
//        public IActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateRecaptcha(Action = nameof(Register),
//            ValidationFailedAction = ValidationFailedAction.ContinueRequest)]
//        public async Task<IActionResult> Register(RegisterFormModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            ApplicationUser user = new ApplicationUser()
//            {
//                FirstName = model.FirstName,
//                LastName = model.LastName
//            };

//            await userManager.SetEmailAsync(user, model.Email);
//            await userManager.SetUserNameAsync(user, model.Email);

//            IdentityResult result =
//                await userManager.CreateAsync(user, model.Password);

//            if (!result.Succeeded)
//            {
//                foreach (IdentityError error in result.Errors)
//                {
//                    ModelState.AddModelError(string.Empty, error.Description);
//                }

//                return View(model);
//            }

//            await signInManager.SignInAsync(user, false);

//            return RedirectToAction("Index", "Home");
//        }

//        [HttpGet]
//        public async Task<IActionResult> Login(string? returnUrl = null)
//        {
//            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

//            LoginFormModel model = new LoginFormModel()
//            {
//                ReturnUrl = returnUrl
//            };

//            return View(model);
//        }

//        [HttpPost]
//        public async Task<IActionResult> Login(LoginFormModel model)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(model);
//            }

//            var result =
//                await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

//            if (!result.Succeeded)
//            {
//                TempData[ErrorMessage] =
//                    "There was an error while logging you in! Please try again later or contact an administrator.";

//                return View(model);
//            }

//            return Redirect(model.ReturnUrl ?? "/Home/Index");
//        }
//    }
//}