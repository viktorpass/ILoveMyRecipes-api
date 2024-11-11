using ILoveMyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.Account {
    public interface IAuthenticate {

        Task<bool> AuthenticateAsync(string email, string senha);
        Task<bool> UserExists(string email);
        public string GenerateToken(int id, string email);
        public Task<User> GetUserByEmail(string email);




    }
}
