using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SampleProject.Entities;
using Microsoft.AspNetCore.Identity;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<CustomIdentityUser> _userManager;
        private RoleManager<CustomIdentityRole> _roleManager;
        private SignInManager<CustomIdentityUser> _signInManager;


        public AccountController(UserManager<CustomIdentityUser> userManager, RoleManager<CustomIdentityRole> roleManager, SignInManager<CustomIdentityUser> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(RegistrationViewModel registrationViewModel)
        {
            if(ModelState.IsValid)
            {
                CustomIdentityUser user = new CustomIdentityUser
                {
                    UserName = registrationViewModel.UserName,
                    Email = registrationViewModel.Email
                };

                IdentityResult result = _userManager.CreateAsync(user, registrationViewModel.Password).Result;

                if(result.Succeeded)
                {
                    if(!_roleManager.RoleExistsAsync("NewUser").Result)
                    {
                        CustomIdentityRole role = new CustomIdentityRole
                        {
                            Name = "NewUser"
                        };

                        IdentityResult roleResult = _roleManager.CreateAsync(role).Result;

                        if(!roleResult.Succeeded)
                        {
                            ModelState.AddModelError("", "We can't add the role!");
                            return View(registrationViewModel);
                        }
                    }

                    _userManager.AddToRoleAsync(user, "NewUser").Wait();

                    return RedirectToAction("Login", "Account");
                }

                return View(registrationViewModel);
            }

            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if(ModelState.IsValid)
            {
               // var result = _signInManager.PasswordSignInAsync();
            }

            return View(loginViewModel);
        }
    }
}
