using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FileStorageManager.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NetChatApp.Areas.Identity.Data;

namespace FileStorageManager.Controllers
{
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
        [Route("api/[controller]")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestViewModel model)
        {
            var user = new AppUser { FirstName = model.FirstName, LastName = model.LastName, FullName = model.FirstName + model.LastName, Email = model.Email, UserName = model.FirstName + model.LastName};
            await _userManager.CreateAsync(user, model.Password);
            Console.WriteLine("register user:" + user.FirstName + user.LastName + "," + user.FullName);
            return Ok(new RegisterResponseModel(user));
        }

        //[HttpGet]
        //[Route(("api/[controller]"))]

    }
}
