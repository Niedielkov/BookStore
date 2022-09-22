using BookStore.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace BookStore.Repositories
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUser(SignUpUserModel signUpUserModel);
        Task<SignInResult> PasswordSignIn(SignInUserModel signInUserModel);
        Task SignOut();
    }
}