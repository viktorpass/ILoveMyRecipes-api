using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.DTOs {
    public class RecipeTypePutDTO {
        public int Id { get; init; }
        public string TypeName { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
