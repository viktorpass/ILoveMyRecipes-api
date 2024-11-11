using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.DTOs {
    public class UserDTO {
        public int Id { get;  set; }
        public string Name { get;  set; }
        public string Email { get;  set; }
        [JsonIgnore]
        public bool IsAdmin { get; set; }
        [NotMapped]
        [MinLength(8)]
        public string Password { get; set; }
    }
}
