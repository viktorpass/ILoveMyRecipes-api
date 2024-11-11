 

namespace ILoveMyRecipes.Application.DTOs {
    public class RecipePutDTO {
        public int Id { get; init; }
        public int RecipeTypeId { get;  set; }
        public int UserId { get; private set; }
        public string Name { get;  set; }
        public string Description { get;  set; }
        public string Ingredients { get;  set; }
        public string MethodOfPreparation { get;  set; }
        public string CreatedBy { get;  set; }
        public DateTime UpdatedAt { get; private set; }

        public RecipePutDTO() {
            UpdatedAt = DateTime.Now;
        }

        //public RecipePutDTO(int id, int recipeTypeId,string name, string description, string ingredients, string methodOfPreparation, string createdBy) {
        //    Id = id;
        //    RecipeTypeId = recipeTypeId;          
        //    Name = name;
        //    Description = description;
        //    Ingredients = ingredients;
        //    MethodOfPreparation = methodOfPreparation;
        //    CreatedBy = createdBy;
        //    UpdatedAt = DateTime.Now;
        //}

        public void addUserId(int userId) {
            UserId = userId;
        }
    }
}
