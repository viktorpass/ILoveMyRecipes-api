using System.ComponentModel.DataAnnotations;

namespace ILoveMyRecipes.API.Models {
    public class LoginModel {
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
