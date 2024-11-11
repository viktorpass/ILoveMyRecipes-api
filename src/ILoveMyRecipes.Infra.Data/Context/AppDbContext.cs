using ILoveMyRecipes.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace ILoveMyRecipes.Infra.Data.Context {
    public class AppDbContext : DbContext {
        public AppDbContext(DbContextOptions options): base(options) {}


        public DbSet<Recipe> Recipe { get; set; }
        public DbSet<RecipeType> RecipeType { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }



    }
}
