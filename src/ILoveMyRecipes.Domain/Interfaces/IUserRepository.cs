using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Infra.Data.Repositories {
    public interface IUserRepository {

        Task<User> Create(User user);
        Task<User> SelectById(int id);
        Task<User> Update(User user);
        Task<User> Delete(int id);
        Task<PagedList<User>> SelectAll(int pageNumber, int pageSize);
        
        //Task<PagedList<User>> SelecionarByFiltroAsync(
        //string nome, string email, bool? isAdmin, int pageNumber, int pageSize);

    }
}
