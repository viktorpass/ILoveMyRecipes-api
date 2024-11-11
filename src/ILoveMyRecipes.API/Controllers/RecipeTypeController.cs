using ILoveMyRecipes.API.Extensions;
using ILoveMyRecipes.API.Models;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace ILoveMyRecipes.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeTypeController : ControllerBase {
        private readonly IRecipeTypeService _recipeTypeService;
        private readonly IUserService _userService;

        public RecipeTypeController(IRecipeTypeService recipeTypeService, IUserService userService) {
            _recipeTypeService = recipeTypeService;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult> GetAllTypes([FromQuery] PaginationParams paginationParams) {

            var recipesTypeDTO = await _recipeTypeService.SelectAll(paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(recipesTypeDTO.CurrentPage, recipesTypeDTO.PageSize, recipesTypeDTO.TotalCount,
                recipesTypeDTO.TotalPages));

            return Ok(recipesTypeDTO);

        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id) {
            var recipeTypeDto = await _recipeTypeService.SelectById(id);
            if(recipeTypeDto is null) {
                return NotFound("Recipe type not found");
            }
            return Ok(recipeTypeDto);

        }

        [HttpPost]
        public async Task<ActionResult> CreateRecipeType(RecipeTypeDTO recipeTypeDTO) {
            var recipeType = await _recipeTypeService.Create(recipeTypeDTO);

            if (recipeType is null) {
                return BadRequest("An error ocurred creating a new Recipe Type");
            }
            return Ok(new { message = "New type added succesfully" });
        }

        [HttpPut]
        public async Task<ActionResult> UpdateRecipeType(RecipeTypePutDTO recipeTypePutDTO) {
            var recipeType = await _recipeTypeService.Update(recipeTypePutDTO);

            if(recipeType is null) {
                return BadRequest("An error ocurred updating the recipe type");
            }
            return Ok(new { message = "Type edited successfully" });

        }
        [HttpDelete]
        public async Task<ActionResult> Delete(int id) {
            //var userId = User.GetId();

            //var user = await _userService.SelectById(userId);

            //if (!user.IsAdmin) {
            //    return Unauthorized("You dont have permission");
            //}

            var deleteRecipe = await _recipeTypeService.Delete(id);
            if (deleteRecipe is null) {
                return BadRequest("An error occurred while deleting the new recipe");
            }
            return Ok("Recipe deleted succesfully");
        }






    }
}
