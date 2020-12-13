using Microsoft.AspNetCore.Identity;
using ShopCet47.Web.Data.Entities;
using ShopCet47.Web.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopCet47.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;


        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            var user = await this.userHelper.GetUserByEmailAsync("carlosmspa@netcabo.pt");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Carlos",
                    LastName = "Alves",
                    Email = "carlosmspa@netcabo.pt",
                    UserName = "carlosmspa@netcabo.pt"

                };
                var result = await this.userHelper.AddUserAsync(user,"123456");
                if(result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            var isRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");

            if (!isRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
            }

            if (!this.context.Products.Any())
            {
                this.AddProduct("iPhone X", user);
                this.AddProduct("Rato Mickey", user);
                this.AddProduct("iWatch Series 4", user);
                this.AddProduct("Ipad 2", user);
                await this.context.SaveChangesAsync();

            }
        }
        private void AddProduct(string name, User user)
        {
            this.context.Products.Add(new Entities.Product
            {
                Name = name,
                Price = this.random.Next(1000),
                IsAvailable = true,
                Stock = this.random.Next(100),
                User = user
            });
        }

    }
}
