using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Models;
using System.Threading.Tasks;

namespace ShopCet47.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email); //confirma se o user ja existe na BD

        Task<IdentityResult> AddUserAsync(User user, string password);// Criar um novo user na BD


        Task<SignInResult> LoginAsync(LoginViewModel model);


        Task LogoutAsync();
    }
}


