using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Domain.Interfaces {
    public interface IRecipeRepository {


        Task<Recipe> Create(Recipe recipe);
        //Task<IEnumerable<Recipe>> SelectAll();
        Task<Recipe> SelectById(int id);
        Task<Recipe> Update(Recipe recipe);
        Task<Recipe> Delete(int id);
      
        Task<PagedList<Recipe>> SelectAll(int userId,int pageNumber, int pageSize);
       



    }
}
