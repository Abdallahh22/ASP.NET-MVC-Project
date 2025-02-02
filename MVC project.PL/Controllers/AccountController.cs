﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MVC_project.PL.ViewModels;
using MVC_Project.DAL.Models;
using System.Threading.Tasks;

namespace MVC_project.PL.Controllers
{
    public class AccountController : Controller
    {
		private readonly UserManager<AuthUser> _userManager;
		private readonly SignInManager<AuthUser> _signInManager;

		public AccountController(UserManager<AuthUser> userManager, SignInManager<AuthUser> signInManager)
        {
			_userManager = userManager;
			_signInManager = signInManager;
		}

		#region SignUp
		[HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> SignUp(SignUpViewModel model)
		{
			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByNameAsync(model.UserName);
				if (user is null)
				{
					user = await _userManager.FindByEmailAsync(model.UserName);

					if (user is null)
					{
						user = new AuthUser()
						{
							UserName = model.UserName,
							Email = model.Email,
							IsAgree = model.IsAgree,
						};
						var result = await _userManager.CreateAsync(user, model.Password);
						if (result.Succeeded) 
							return RedirectToAction(nameof(SignIn));
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);	
                        }

                    };


				}
					ModelState.AddModelError(string.Empty, errorMessage: "Username is Already Exits");
			}

				

			return View(model);
		}


		#endregion


		#region SignIn

		[HttpGet]
		public IActionResult SignIn()
		{

			return View();
		}

		[HttpPost]
		public async Task<IActionResult> SignIn(SignInViewModel model)
		{

			if (ModelState.IsValid)
			{
				var user = await _userManager.FindByEmailAsync(model.Email);
				if (user is not null)
				{
					var flag = await _userManager.CheckPasswordAsync(user, model.Password);
					if (flag)
					{
					  var result = 	await _signInManager.PasswordSignInAsync(user,model.Password, model.RememberMe ,false);
                        if (result.Succeeded)
                        {
							return RedirectToAction(nameof(HomeController.Index), "Home");
                        }
                    }
				}

				ModelState.AddModelError(string.Empty, errorMessage: "Invalid Login");

			}

			return View(model);
		}

		#endregion

		#region SignOut

		public async Task<IActionResult> SignOut()
		{
			await _signInManager.SignOutAsync();
			return RedirectToAction(nameof(SignIn));
		}

		#endregion


		#region Forget Password

		public IActionResult ForgetPassword()
		{
			return View();
		}



		#endregion


	}
}
