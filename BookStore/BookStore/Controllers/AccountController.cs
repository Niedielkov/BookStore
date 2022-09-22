using BookStore.Models;
using BookStore.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAccountRepository _accountRepository;

        public AccountController(IAccountRepository accountRepository)
        {
            _accountRepository = accountRepository;
        }

        public IActionResult SignUp(bool isSuccess = false)
        {
            ViewBag.IsSuccess = isSuccess;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpUserModel signUpUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.CreateUser(signUpUserModel);
                if (!result.Succeeded)
                {
                    foreach(var errorMessage in result.Errors)
                    {
                        ModelState.AddModelError("", errorMessage.Description);
                    }

                    return View();
                }

                ModelState.Clear();
                return RedirectToAction(nameof(SignUp), new { isSuccess = true });
            }

            return View();
        }

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(SignInUserModel signInUserModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _accountRepository.PasswordSignIn(signInUserModel);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }

                ModelState.AddModelError("", "Wrong data");
            }

            return View(signInUserModel);
        }

        public async Task<IActionResult> Logout()
        {
            await _accountRepository.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}
