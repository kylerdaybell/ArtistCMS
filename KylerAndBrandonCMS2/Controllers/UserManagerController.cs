using KylerAndBrandonCMS2.Data;
using KylerAndBrandonCMS2.Models;
using KylerAndBrandonCMS2.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KylerAndBrandonCMS2.Controllers
{
    public class UserManagerController: Controller
    {
        private readonly IPageManagerService _pageManagerService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly CmsContext _context;

        public UserManagerController(IPageManagerService pageManagerService, UserManager<IdentityUser> userManager, CmsContext context, SignInManager<IdentityUser> signInManager)
        {
            _pageManagerService = pageManagerService;
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email,Password")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                bool valid = false;
                IdentityUser User = new IdentityUser();
                if (user.Email != null && user.Password != null)
                {
                    User = await _userManager.FindByEmailAsync(user.Email);
                    valid = await _userManager.CheckPasswordAsync(User, user.Password);
                }

                if (valid)
                {
                    await _signInManager.SignInAsync(User, true);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return RedirectToAction("Login", "Home");
                }
            }
            return View("../Home/Login", user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> RegisterUser([Bind("Email,Password")] UserModel user)
        {
            if (ModelState.IsValid)
            {
                IdentityUser User = new IdentityUser(user.Email);
                User.Email = user.Email;
                User.NormalizedEmail = user.Email.ToUpper();

                await _userManager.CreateAsync(User, user.Password);


                return RedirectToAction("Login", "Home");
            }

            return View("../Home/Register",user);
        }
    }
}
