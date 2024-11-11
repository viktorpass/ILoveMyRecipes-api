using ILoveMyRecipes.Application.Account;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Infra.Data.Identity {
    public class AuthenticateService : IAuthenticate {
        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthenticateService(AppDbContext context, IConfiguration configuration) {
            _context = context;
            _configuration = configuration;
        }
        public async Task<bool> AuthenticateAsync(string email, string senha) {
            var usuario = await _context.User.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null) {
                return false;
            }

            using var hmac = new HMACSHA512(usuario.PasswordSalt);
            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(senha));
            for (int x = 0; x < computedHash.Length; x++) {
                if (computedHash[x] != usuario.PasswordHash[x]) return false;
            }

            return true;
        }

        public string GenerateToken(int id, string email) {
            var claims = new[]
            {
                new Claim("id", id.ToString()),
                new Claim("email", email.ToLower()),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };


#pragma warning disable CS8604 // Possible null reference argument.
            var privateKey = new SymmetricSecurityKey(Encoding.UTF8.
                GetBytes(_configuration["jwt:secretKey"]));
#pragma warning restore CS8604 // Possible null reference argument.


            var credentials = new SigningCredentials(privateKey, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddMinutes(10);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["jwt:issuer"],
                audience: _configuration["jwt:audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: credentials
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<User> GetUserByEmail(string email) {

#pragma warning disable CS8603 // Possible null reference return.
            return await _context.User.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
#pragma warning restore CS8603 // Possible null reference return.

        }

        public async Task<bool> UserExists(string email) {
            var usuario = await _context.User.Where(x => x.Email.ToLower() == email.ToLower()).FirstOrDefaultAsync();
            if (usuario == null) {
                return false;
            }

            return true;
        }
    }
}

