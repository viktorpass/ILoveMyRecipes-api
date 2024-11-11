using ILoveMyRecipes.Domain.Validations;


namespace ILoveMyRecipes.Domain.Entities {
    public class Recipe  {

        public int Id { get;  private set; }
        public int RecipeTypeId { get; private set; }
        public int UserId { get; private set; }
        public string Name { get; private set; } = string.Empty;
        public string Description { get; private set; } = string.Empty;
        public string Ingredients { get; private set; } = string.Empty;
        public string MethodOfPreparation { get; private set; } = string.Empty;
        public string CreatedBy { get; private set; } = string.Empty;
        public DateTime CreatedAt { get; private set; } = DateTime.Now;
        public DateTime UpdatedAt { get; private set; } = DateTime.Now;
        public RecipeType recipeType { get; set; }
        public User user { get; set; }

        void ValidateDomain(int recipeTypeId,string name, string description, string ingredients, string methodOfPreparation, string createdBy
            ) {
            DomainExceptionValidation.When(name.Length > 50, "The recipe name needs to be short than that");
            DomainExceptionValidation.When(description.Length > 500, "The description needs to be short than that");
            DomainExceptionValidation.When(ingredients.Length > 300, "The Ingredients needs to be short than that");
            DomainExceptionValidation.When(methodOfPreparation.Length > 1000, "The method of preparation needs to be short than that");
            DomainExceptionValidation.When(createdBy.Length > 50, "The created by field needs to be short than that");

            RecipeTypeId = recipeTypeId;
            Name = name;
            Description = description;
            Ingredients = ingredients;
            MethodOfPreparation = methodOfPreparation;
            CreatedBy = createdBy;
  
        }
        
        public void UpdateRecipe(Recipe recipe) {
            ValidateDomain(recipe.RecipeTypeId, recipe.Name, recipe.Description, recipe.Ingredients, recipe.MethodOfPreparation,
                recipe.CreatedBy);
            
            UpdatedAt = recipe.UpdatedAt;
        }
        public Recipe(int recipeTypeId,int userId, string name, string description, string ingredients, string methodOfPreparation, string createdBy) {
            UserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ValidateDomain(recipeTypeId, name, description, ingredients, methodOfPreparation, createdBy);
        }
        public Recipe(int id, int recipeTypeId,int userId, string name, string description, string ingredients, string methodOfPreparation, string createdBy) {
            Id = id;
            UserId = userId;
            CreatedAt = DateTime.Now;
            UpdatedAt = DateTime.Now;
            ValidateDomain(recipeTypeId, name, description, ingredients, methodOfPreparation, createdBy);
        }







    }
}
