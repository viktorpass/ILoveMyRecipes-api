using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Domain.Pagination;


namespace ILoveMyRecipes.Application.Interfaces {
    public interface IRecipeTypeService {
        Task<RecipeTypeDTO> Create(RecipeTypeDTO recipeTypeDTO);
        Task<RecipeTypePutDTO> Update(RecipeTypePutDTO recipeTypeDTO);
        Task<RecipeTypeDTO> Delete(int id);
        Task<PagedList<RecipeTypeDTO>> SelectAll(int pageNumber, int pageSize);
        Task<RecipeTypeDTO> SelectById(int id);
    }
}
