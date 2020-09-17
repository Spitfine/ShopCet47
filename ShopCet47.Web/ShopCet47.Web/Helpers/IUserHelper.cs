using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Helpers
{
    public interface IUserHelper
    {
        Task<User> GetUserByEmailAsync(string email); //confirma se o user ja existe na BD

        Task<IdentityResult> AddUserAsync(User user, string password);// Criar um novo user na BD
    }
}


