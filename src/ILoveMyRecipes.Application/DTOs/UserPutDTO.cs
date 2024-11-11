using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.DTOs {
    public class UserPutDTO {
        [Required(ErrorMessage = "O Id é obrigatório")]
        public int Id { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório")]
        [MaxLength(250, ErrorMessage = "O nome não pode ter mais de 250 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        [MaxLength(250, ErrorMessage = "O E-mail não pode ter mais de 200 caracteres")]
        public string Email { get; set; }
        [MaxLength(100, ErrorMessage = "A senha deve ter, no máximo, 100 caracteres.")]
        [MinLength(8, ErrorMessage = "A senha deve ter, no mínimo, 8 caracteres.")]
        [NotMapped]
        public string Password { get; set; }
        //[JsonIgnore]
        public bool IsAdmin { get; set; }
    }
}
