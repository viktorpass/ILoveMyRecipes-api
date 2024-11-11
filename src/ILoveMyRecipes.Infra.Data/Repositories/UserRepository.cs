using ILoveMyRecipes.Domain.Entities;
using ILoveMyRecipes.Domain.Pagination;
using ILoveMyRecipes.Infra.Data.Context;
using ILoveMyRecipes.Infra.Data.Helpers;
using Microsoft.EntityFrameworkCore;


namespace ILoveMyRecipes.Infra.Data.Repositories {
    public class UserRepository : IUserRepository{
        
            private readonly AppDbContext _context;

            public UserRepository(AppDbContext context) {
                _context = context;
            }

            public async Task<User> Update(User user) {
                if (user.PasswordSalt == null || user.PasswordHash == null) {
                    var EncryptedPassword = await _context.User.Where(x => x.Id == user.Id).Select(x => new { x.PasswordHash, x.PasswordSalt }).FirstOrDefaultAsync();

                    user.ChangePassword(EncryptedPassword.PasswordHash, EncryptedPassword.PasswordSalt);

                }

                _context.User.Update(user);
                await _context.SaveChangesAsync();
                return user;
            }

            public async Task<User> Delete(int id) {
                var user = await _context.User.FindAsync(id);
                if (user != null) {
                    _context.User.Remove(user);
                    await _context.SaveChangesAsync();
                    return user;
                }

                return null;
            }


            public async Task<User> Create(User User) {
                _context.User.Add(User);
                await _context.SaveChangesAsync();
                return User;
            }

            public async Task<User> SelectById(int id) {
                return await _context.User.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            }

            public async Task<PagedList<User>> SelectAll(int pageNumber, int pageSize) {
                var query = _context.User.AsQueryable();
                return await PaginationHelper.CreateAsync(query, pageNumber, pageSize);
        }

           
    }



    }

