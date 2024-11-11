using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Interfaces;
using ILoveMyRecipes.Domain.Pagination;
using ILoveMyRecipes.Infra.Data.Context;
using ILoveMyRecipes.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update;


namespace ILoveMyRecipes.Infra.Data.Repositories {
    public class RecipeTypeRepository : IRecipeTypeRepository {
        private readonly AppDbContext _context;

        public RecipeTypeRepository(AppDbContext context) {
            _context = context;
        }

        public async Task<RecipeType> Create(RecipeType recipeType) {
            _context.RecipeType.Add(recipeType);
            await _context.SaveChangesAsync();
            return recipeType;
        }

        public async Task<RecipeType> Delete(int id) {

            var recipeType = _context.RecipeType.FirstOrDefault(x => x.Id == id);
            _context.RecipeType.Remove(recipeType);
            await _context.SaveChangesAsync();
            return recipeType;

        }

       

        public async Task<PagedList<RecipeType>> SelectAll(int pageNumber, int pageSize) {
            //var allTypes = await _context.RecipeType.ToListAsync();
            //return allTypes;
            var query = _context.RecipeType.AsQueryable();
            return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);

        }

        public async Task<RecipeType> SelectById(int id) {
            var returnType = await _context.RecipeType.Where(x => x.Id == id).FirstOrDefaultAsync();
            return returnType;
        }

        public async Task<RecipeType> Update(RecipeType recipeType) {
            //_context.Entry(recipeType).State = EntityState.Modified;
            var toUpdate = await  _context.RecipeType.SingleOrDefaultAsync(x => x.Id == recipeType.Id);
            
            toUpdate.UpdateRecipeType(recipeType);
            await _context.SaveChangesAsync();
            return toUpdate;

        }
    }
}
