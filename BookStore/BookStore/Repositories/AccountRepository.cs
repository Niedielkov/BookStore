using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AccountRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> CreateUser(SignUpUserModel signUpUserModel)
        {
            var user = new IdentityUser()
            {
                Email = signUpUserModel.Email,
                UserName = signUpUserModel.Email
            };

            var result = await _userManager.CreateAsync(user, signUpUserModel.Password);
            return result;
        }

        public async Task<SignInResult> PasswordSignIn(SignInUserModel signInUserModel)
        {
            var result = await _signInManager.PasswordSignInAsync(signInUserModel.Email, signInUserModel.Password, signInUserModel.RememberMe, false);
            return result;
        }

        public async Task SignOut()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
