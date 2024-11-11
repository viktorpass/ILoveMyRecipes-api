using ILoveMyRecipes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace ILoveMyRecipes.Infra.Data.EntitiesConfiguration {
    public class RecipeTypeConfiguration : IEntityTypeConfiguration<RecipeType> {
        public void Configure(EntityTypeBuilder<RecipeType> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.TypeName).IsRequired().HasMaxLength(100);

            builder.HasOne(x => x.user).WithMany(x => x.recipeTypes)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
