using AutoMapper;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Interfaces;
using ILoveMyRecipes.Domain.Pagination;


namespace ILoveMyRecipes.Application.Services {
    public class RecipeTypeService : IRecipeTypeService {
        private readonly IMapper _mapper;
        private readonly IRecipeTypeRepository _recipeTypeRepository;

        public RecipeTypeService(IMapper mapper, IRecipeTypeRepository recipeTypeRepository) {
            _mapper = mapper;
            _recipeTypeRepository = recipeTypeRepository;
        }

        public async Task<RecipeTypeDTO> Create(RecipeTypeDTO recipeTypeDTO) {
            var recipeTypeToCreate = _mapper.Map<RecipeType>(recipeTypeDTO);
            await _recipeTypeRepository.Create(recipeTypeToCreate);
            return _mapper.Map<RecipeTypeDTO>(recipeTypeToCreate);
        }

        public async Task<RecipeTypeDTO> Delete(int id) {
            var recipeTypeToDelete = await _recipeTypeRepository.Delete(id);
            return _mapper.Map<RecipeTypeDTO>(recipeTypeToDelete);
        }


        public async Task<PagedList<RecipeTypeDTO>> SelectAll(int pageNumber, int pageSize) {
            //var recipeTypes = await _recipeTypeRepository.SelectAll();
            //return _mapper.Map<IEnumerable<RecipeTypeDTO>>(recipeTypes);

            var types = await _recipeTypeRepository.SelectAll(pageNumber, pageSize);
            var typesDTO = _mapper.Map<IEnumerable<RecipeTypeDTO>>(types);

            return new PagedList<RecipeTypeDTO>(typesDTO, pageNumber, pageSize, types.TotalCount);



        }

        public async Task<RecipeTypeDTO> SelectById(int id) {
            var recipeType = await _recipeTypeRepository.SelectById(id);
            return _mapper.Map<RecipeTypeDTO>(recipeType);
        }

        public async Task<RecipeTypePutDTO> Update(RecipeTypePutDTO recipeTypePutDTO) {
            var recipeTypeToUpdate = _mapper.Map<RecipeType>(recipeTypePutDTO);
            await _recipeTypeRepository.Update(recipeTypeToUpdate);
            return recipeTypePutDTO;
        }
    }
}
