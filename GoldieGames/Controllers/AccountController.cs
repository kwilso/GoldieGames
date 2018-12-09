﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GoldieGames.Models.ViewModels;
using GoldieGames.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;


namespace GoldieGames.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private RoleManager<IdentityRole> roleManager;
        private UserManager<IdentityUser> userManager;
        private SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userMgr,
        SignInManager<IdentityUser> signInMgr, RoleManager<IdentityRole> roleMgr )
        {
            userManager = userMgr;
            signInManager = signInMgr;
            roleManager = roleMgr;

        }
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user =
                await userManager.FindByNameAsync(loginModel.Name);
                if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        /*return Redirect(loginModel?.ReturnUrl ?? "/Games/Index");*/
                        return View("Games/Index");
                    }
                }
            }
        ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        

        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create(CreateModel model)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser
                {
                    UserName = model.Name,
                    Email = model.Email
                };
                IdentityResult result
                = await userManager.CreateAsync(user, model.Password);
                result = await roleManager.CreateAsync(new IdentityRole("User"));
                if (result.Succeeded)
                {
                    return View("Login");
                }
                else
                {
                    foreach (IdentityError error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }
            }
            return View(model);
        }

        [AllowAnonymous]
        public ViewResult Create()
        {
            return View("Create");
        }


    }
}