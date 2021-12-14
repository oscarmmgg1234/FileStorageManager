﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileStorageManager.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetChatApp.Areas.Identity.Data;

namespace FileStorageManager.Controllers
{
    [ApiController]
    [Route("api/Account/[action]")]
    public class AccountController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterRequestViewModel model)
        {
            Console.WriteLine("register");
            // if model has errors such as password to short or email is in wrong format
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = new AppUser { FirstName = model.FirstName, LastName = model.LastName, FullName = model.FirstName + model.LastName, Email = model.Email, UserName = model.FirstName + model.LastName };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors);
            return Ok(new RegisterResponseModel(user));
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromForm] LoginUserRequestModel model)
        {
            Console.WriteLine("email:" + model.Email + "password:" + model.Password);
            var results = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
            var returnUrl = "https://localhost:5001/";
            if(results.Succeeded)
            {
                Console.WriteLine("user:" + model.Email + "logged in");
                return Redirect(returnUrl);
            }

            return Redirect(returnUrl);

        }


    }
}
