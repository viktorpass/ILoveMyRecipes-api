using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Domain.Interfaces {
    public interface IRecipeTypeRepository {

        Task<RecipeType> Create(RecipeType recipeType);
        Task<RecipeType> Update(RecipeType recipeType);
        Task<RecipeType> Delete(int id);
        Task<PagedList<RecipeType>> SelectAll(int pageNumber, int pageSize);
        Task<RecipeType> SelectById(int id);
  


    }
}
