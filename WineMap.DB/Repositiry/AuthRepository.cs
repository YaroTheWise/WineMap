﻿using System;

using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using WineMap.DB.Models;

namespace WineMap.DB.Repositiry
{
    public class AuthRepository : IDisposable
    {
        private AuthContext context;

        private UserManager<IdentityUser> userManager;

        public AuthRepository()
        {
            context = new AuthContext();
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }

        public async Task<IdentityResult> RegisterUser(User userModel)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = userModel.UserName
            };

            var result = await userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            context.Dispose();
            userManager.Dispose();

        }
    }
}
