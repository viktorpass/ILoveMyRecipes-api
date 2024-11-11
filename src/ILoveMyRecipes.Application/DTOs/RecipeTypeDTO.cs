using ILoveMyRecipes.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.DTOs {
    public class RecipeTypeDTO {

        public int Id { get; private set; }
        public string TypeName { get; set; } = string.Empty;
        
        //public Recipe Recipe { get; set; }
    }
}
