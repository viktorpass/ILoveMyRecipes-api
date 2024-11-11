using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;


namespace ILoveMyRecipes.Application.Interfaces {
    public interface IRecipeService {
        Task<RecipeDTO> Create(RecipeDTO recipeDTO);
        Task<PagedList<RecipeDTO>> SelectAll(int userId,int pageNumber, int pageSize);
        Task<RecipeDTO> SelectById(int id, int userId);
        Task<RecipePutDTO> Update(RecipePutDTO recipePutDTO);
        Task<RecipeDTO> Delete(int id, int userId);
    }
}
