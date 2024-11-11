using ILoveMyRecipes.Domain.Validations;


namespace ILoveMyRecipes.Domain.Entities {
    public class RecipeType {
        public int Id { get; private set; }
        public int UserId { get; private set; }
        public string TypeName { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;

        public User user { get; set; }
        public ICollection<Recipe> recipes { get; set; }
        
        void ValidateRecipeType(int userId,string typeName) {
            DomainExceptionValidation.When(typeName.Length > 50, "The type name needs to be shorter than that");
            UserId = userId;
            TypeName = typeName;
            
            
        }
    
        public RecipeType(int userId, string typeName, DateTime createdAt, DateTime updatedAt) {
            ValidateRecipeType(userId, typeName);
        }

        public RecipeType(int id, int userId, string typeName) {
            Id = id;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ValidateRecipeType(userId, typeName);
        }

        public void UpdateRecipeType(RecipeType recipeType) {
            TypeName = recipeType.TypeName;
            UpdatedAt = recipeType.UpdatedAt;
        }

    }
}
