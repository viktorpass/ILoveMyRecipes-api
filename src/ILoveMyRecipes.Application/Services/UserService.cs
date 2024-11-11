using AutoMapper;
using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Application.Interfaces;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;
using ILoveMyRecipes.Infra.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.Services {

    public class UserService : IUserService {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper) {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<UserDTO> Create(UserDTO userDTO) {
            var user = _mapper.Map<User>(userDTO);

            if (userDTO.Password != null) {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(userDTO.Password));
                byte[] passwordSalt = hmac.Key;

                user.ChangePassword(passwordHash, passwordSalt);
            }

            var usuarioIncluido = await _repository.Create(user);
            return _mapper.Map<UserDTO>(usuarioIncluido);
        }

        public async Task<UserDTO> Delete(int id) {
            var usuario = await _repository.Delete(id);
            return _mapper.Map<UserDTO>(usuario);
        }

       

        public async Task<PagedList<UserDTO>> SelectAll(int pageNumber, int pageSize) {
            var usuarios = await _repository.SelectAll(pageNumber, pageSize);
            var usuariosDTO = _mapper.Map<IEnumerable<UserDTO>>(usuarios);
            return new PagedList<UserDTO>
                (usuariosDTO, pageNumber, usuarios.TotalPages, usuarios.PageSize, usuarios.TotalCount);
        }
    

        public async Task<UserDTO> SelectById(int id) {
            var usuario = await _repository.SelectById(id);
            return _mapper.Map<UserDTO>(usuario);
        }

        public async Task<UserPutDTO> Update(UserPutDTO usuarioPutDTO) {
            var usuario = _mapper.Map<User>(usuarioPutDTO);


            if (usuarioPutDTO.Password != null) {
                using var hmac = new HMACSHA512();
                byte[] passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(usuarioPutDTO.Password));
                byte[] passwordSalt = hmac.Key;

                usuario.ChangePassword(passwordHash, passwordSalt);

            }

            var usuarioAlterado = await _repository.Update(usuario);
            return _mapper.Map<UserPutDTO>(usuarioAlterado);
        }

        
    }
}
