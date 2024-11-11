using ILoveMyRecipes.API.Extensions;
using ILoveMyRecipes.API.Models;
using ILoveMyRecipes.Application.Account;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Infra.Ioc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ILoveMyRecipes.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase {

        private readonly IAuthenticate _authenticateService;
        private readonly IUserService _userService;

        public UserController(IAuthenticate authenticateService, IUserService userService) {
            _authenticateService = authenticateService;
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserToken>> Incluir(UserDTO userDTO) {

            //if (userDTO == null) {
            //    return BadRequest("Dados inválidos");
            //}

            //var emailExiste = await _authenticateService.UserExists(userDTO.Email);

            //if (emailExiste) {
            //    return BadRequest("Este e-mail já possui um cadastro.");
            //}

            //var userId = User.GetId();
            //var user = await _userService.SelectById(userId);
            //if (!user.IsAdmin) {
            //        return Unauthorized("Você não tem permissão para incluir novos usuários.");
            // }

            var usuario = await _userService.Create(userDTO);
            //if (usuario == null) {
            //    return BadRequest("Ocorreu um erro ao cadastrar.");
            //}

            //var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);
            //return new UserToken {
            //    Token = token
            //};

            return Ok(new { message = "Usuário incluído com sucesso!" });

        }

        [HttpPost("login")]
        public async Task<ActionResult<UserToken>> Selecionar(LoginModel loginModel) {
            var existe = await _authenticateService.UserExists(loginModel.Email);
            if (!existe) {
                return Unauthorized("Usuário não existe.");
            }

            var result = await _authenticateService.AuthenticateAsync(loginModel.Email, loginModel.Password);
            if (!result) {
                return Unauthorized("Usuário ou senha inválido.");
            }

            var usuario = await _authenticateService.GetUserByEmail(loginModel.Email);

            var token = _authenticateService.GenerateToken(usuario.Id, usuario.Email);

            return new UserToken {
                Token = token,
                IsAdmin = usuario.IsAdmin,
                Email = usuario.Email
            };
        }

        [HttpGet]
        
        public async Task<ActionResult> SelecionarTodos([FromQuery]PaginationParams paginationParams) {
            var userId = User.GetId();
            var user = await _userService.SelectById(userId);

            if (!user.IsAdmin) {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuarios = await _userService.SelectAll(paginationParams.PageNumber, paginationParams.PageSize);
            Response.AddPaginationHeader(new PaginationHeader(paginationParams.PageNumber, usuarios.PageSize,
                usuarios.TotalCount, usuarios.TotalPages));
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult> SelecionarById(int id) {
            var userId = User.GetId();
            var user = await _userService.SelectById(userId);

            if (id == 0) {
                id = userId;
            }

            if (!user.IsAdmin && user.Id != id) {
                return Unauthorized("Você não tem permissão para consultar os usuários do sistema.");
            }

            var usuario = await _userService.SelectById(id);
            return Ok(usuario);
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<ActionResult> Excluir(int id) {
            var userId = User.GetId();
            var user = await _userService.SelectById(userId);

            if (!user.IsAdmin) {
                return Unauthorized("Você não tem permissão para excluir os usuários do sistema.");
            }

            var usuario = await _userService.Delete(id);
            return Ok(usuario);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Alterar(UserPutDTO userPutDTO) {
            var userId = User.GetId();
            var user = await _userService.SelectById(userId);


            if (!user.IsAdmin && userPutDTO.Id != userId) {
                return Unauthorized("Você não tem permissão para alterar os usuários do sistema.");
            }

            if (!user.IsAdmin && userPutDTO.Id == userId && userPutDTO.IsAdmin) {
                return Unauthorized("Você não tem permissão para definir você mesmo como administrador.");
            }
            
            await _userService.Update(userPutDTO);

            return Ok(new { message = "Usuário alterado com sucesso!" });
        }







    }
}
