using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Interfaces;
using ILoveMyRecipes.Domain.Pagination;
using ILoveMyRecipes.Infra.Data.Context;
using ILoveMyRecipes.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
namespace ILoveMyRecipes.Infra.Data.Repositories {
    public class RecipeRepository : IRecipeRepository {
        private readonly AppDbContext _context;

        public RecipeRepository(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<Recipe> Create(Recipe recipe) {
            
            _context.Recipe.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        public async Task<Recipe> Delete(int id) {
            var itemToDelete = await _context.Recipe.FirstOrDefaultAsync(x => x.Id == id);


            _context.Recipe.Remove(itemToDelete);

            await _context.SaveChangesAsync();
            return itemToDelete;
            
        }

      

        public async Task<PagedList<Recipe>> SelectAll(int userId,int pageNumber, int pageSize) {
            //var all = await _context.Recipe.ToListAsync();
            // return all;
            var query = _context.Recipe.Where(x => x.UserId == userId).AsQueryable();
            
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

        public async Task<Recipe> SelectById(int id) {
            var recipeById = await _context.Recipe.Where(x => x.Id == id).FirstOrDefaultAsync();
            
            return recipeById;

        }


        public async Task<Recipe> Update(Recipe recipe) {
            // _context.Entry(recipe).State = EntityState.Modified;
           var recipeUpdate = await _context.Recipe.Where(x => x.UserId == recipe.UserId).FirstOrDefaultAsync(x => x.Id == recipe.Id);
            if(recipeUpdate is null) {
                throw new Exception("That information is not yours");
            }
            recipeUpdate.UpdateRecipe(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

    }
}
