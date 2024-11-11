using ILoveMyRecipes.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Domain.Entities {
    public class User {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public bool IsAdmin { get; private set; }
        public byte[] PasswordHash { get; private set; }
        public byte[] PasswordSalt { get; private set; }
        public ICollection<Recipe> recipes { get; set; }
        public ICollection<RecipeType> recipeTypes { get; set; }

        public User(int id, string name, string email) {
            DomainExceptionValidation.When(id < 0, "O id não pode ser negativo.");
            Id = id;
            ValidateDomain(name, email);

        }
        public User(string name, string email) {
            ValidateDomain(name, email);
        }

        public void SetAdmin(bool isAdmin) {
            IsAdmin = isAdmin;
        }

        public void ChangePassword(byte[] passwordHash, byte[] passwordSalt) {
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }

        private void ValidateDomain(string name, string email) {
            DomainExceptionValidation.When(name == null, "Name is required");
            DomainExceptionValidation.When(email == null, "Email is required");

            DomainExceptionValidation.When(name.Length > 250, "O nome não pode ultrapassar de 250 caracteres.");

            DomainExceptionValidation.When(email.Length > 200, "O nome não pode ultrapassar de 200 caracteres.");

            Name = name;
            Email = email;
            IsAdmin = false;
        }


    }
}
