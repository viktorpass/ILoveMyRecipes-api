using ILoveMyRecipes.API.Extensions;
using ILoveMyRecipes.API.Models;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Infra.Data.Helpers;
using ILoveMyRecipes.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;

namespace ILoveMyRecipes.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase {
        private readonly IRecipeService _recipeService;
        private readonly IUserService _userService;

        public RecipeController(IRecipeService recipeService, IUserService userService) {
            _recipeService = recipeService;
            _userService = userService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(RecipeDTO recipeDTO) {
            var userId = User.GetId();
            recipeDTO.addUserId(userId);
            var createRecipe = await _recipeService.Create(recipeDTO);
            if (createRecipe is null) {
                return BadRequest("An error occurred while creating the new recipe");
            }
            return Ok(new { message = "Cliente incluído com sucesso!" });
        }

        [HttpPut]
        public async Task<ActionResult> Update(RecipePutDTO recipePutDTO) {
            var userId = User.GetId();
            recipePutDTO.addUserId(userId);
            
            var updateRecipe = await _recipeService.Update(recipePutDTO);

            if (updateRecipe is null) {
                return BadRequest("An error occurred while updating the new recipe");
            }

            return Ok("Recipe updated succesfully");
        }

        [HttpDelete]
        public async Task<ActionResult> Delete(int id) {
            var userId = User.GetId();

            var deleteRecipe = await _recipeService.Delete(id,userId);
            
            if (deleteRecipe is null) {
                return BadRequest("An error occurred while deleting the new recipe");
            }
            return Ok("Recipe deleted succesfully");
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id) {
            var userId = User.GetId();
            var recipeDTO = await _recipeService.SelectById(id,userId);
            if(recipeDTO is null) {
                NotFound("Recipe not found");
            }
            return Ok(recipeDTO);
        }


        [HttpGet]
        
        public async Task<ActionResult> Get([FromQuery]PaginationParams paginationParams) {
            var userId = User.GetId();
            var clientesDTO = await _recipeService.SelectAll(userId, paginationParams.PageNumber, paginationParams.PageSize);

            Response.AddPaginationHeader(new PaginationHeader(clientesDTO.CurrentPage,
                clientesDTO.PageSize, clientesDTO.TotalCount, clientesDTO.TotalPages));

            return Ok(clientesDTO);

        } 

    }
}
