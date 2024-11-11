namespace ILoveMyRecipes.Application.DTOs {
    public class RecipeDTO {
        public int Id { get; private set; }
        public int RecipeTypeId { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; } 
        public string Description { get; private set; }
        public string Ingredients { get; private set; } 
        public string MethodOfPreparation { get; private set; } 
        public string CreatedBy { get; private set; } 
        public DateTime CreatedAt { get;  private set; }
        public DateTime UpdatedAt { get; private set; }

        public RecipeDTO(int recipeTypeId, string name, string description, string ingredients, string methodOfPreparation, string createdBy) {
            
            RecipeTypeId = recipeTypeId;           
            Name = name;
            Description = description;
            Ingredients = ingredients;
            MethodOfPreparation = methodOfPreparation;
            CreatedBy = createdBy;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            
        }
        public void addUserId(int userId) {
            UserId = userId;
        }
    }
}
