using ILoveMyRecipes.Application.DTOs;
using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Application.Interfaces {
    public interface IUserService {
        Task<UserDTO> Create(UserDTO userDTO);
        //Task<IEnumerable<UserDTO>> SelectAll();
        Task<UserDTO> SelectById(int id);
        Task<UserPutDTO> Update(UserPutDTO userPutDTO);
        Task<UserDTO> Delete(int id);
        Task<PagedList<UserDTO>> SelectAll(int pageNumber, int pageSize);
        //Task<PagedList<UserDTO>> SelecionarByFiltroAsync(
        //string nome, string email, bool? isAdmin, int pageNumber, int pageSize);



    }
}
