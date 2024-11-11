using AutoMapper;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Interfaces;
using ILoveMyRecipes.Domain.Pagination;
using System.Text.Json;

namespace ILoveMyRecipes.Application.Services {
    public class RecipeService : IRecipeService {
        private readonly IMapper _mapper;
        private readonly IRecipeRepository _recipeRepository;

        public RecipeService(IMapper mapper, IRecipeRepository recipeRepository) {
            _mapper = mapper;
            _recipeRepository = recipeRepository;
        }

        public async Task<RecipeDTO> Create(RecipeDTO recipeDTO) {
            var recipeToAdd = _mapper.Map<Recipe>(recipeDTO);
            
            await _recipeRepository.Create(recipeToAdd);
            return _mapper.Map<RecipeDTO>(recipeToAdd);


        }

        public async Task<RecipeDTO> Delete(int id, int userId) {
            var recipeToDelete = await _recipeRepository.Delete(id);
            return _mapper.Map<RecipeDTO>(recipeToDelete);
        }

        public async Task<PagedList<RecipeDTO>> SelectAll(int userId,int pageNumber, int pageSize) {
            //var allRecipes = await _recipeRepository.SelectAll();
            // return _mapper.Map<IEnumerable<RecipeDTO>>(allRecipes);
            
            var recipes = await _recipeRepository.SelectAll(userId,pageNumber, pageSize);
            var recipesDTO = _mapper.Map<IEnumerable<RecipeDTO>>(recipes);

            return new PagedList<RecipeDTO>(recipesDTO, pageNumber, pageSize, recipes.TotalCount);


        }

        public async Task<RecipeDTO> SelectById(int id,int userId) {
            var recipe = await _recipeRepository.SelectById(id);
            return _mapper.Map<RecipeDTO>(recipe);
        }

        public async Task<RecipePutDTO> Update(RecipePutDTO recipePutDTO) {
            var recipeToUpdate = _mapper.Map<Recipe>(recipePutDTO);
            await _recipeRepository.Update(recipeToUpdate);
            return _mapper.Map<RecipePutDTO>(recipeToUpdate);
        }
    }
}
