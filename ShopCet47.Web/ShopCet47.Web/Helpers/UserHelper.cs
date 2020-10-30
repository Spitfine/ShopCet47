using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Models;
using System.Threading.Tasks;

namespace ShopCet47.Web.Helpers
{
    public class UserHelper : IUserHelper
    {
        private readonly UserManager<User> userManager;
        private readonly SignInManager<User> signInManager;

        public UserHelper(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        public async Task<IdentityResult> AddUserAsync(User user, string password)
        {
            return await userManager.CreateAsync(user, password);
        }

        public async Task<IdentityResult> ChangePasswordAsync(User user, string oldPassword, string newPassword)
        {
            return await this.userManager.ChangePasswordAsync(user, oldPassword, newPassword);
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await userManager.FindByNameAsync(email);
        }

        public async Task<SignInResult> LoginAsync(LoginViewModel model)
        {
            return await this.signInManager.PasswordSignInAsync(
                model.Username,
                model.Password,
                model.RememberMe,
                false);
        }

        public async Task LogoutAsync()
        {
            await this.signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> UpdateUserAsync(User user)
        {
           return await this.userManager.UpdateAsync(user);
        }
    }

}
