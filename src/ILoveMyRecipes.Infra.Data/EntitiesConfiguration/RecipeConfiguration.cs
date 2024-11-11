using ILoveMyRecipes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Infra.Data.EntitiesConfiguration {
    public class RecipeConfiguration : IEntityTypeConfiguration<Recipe> {

        public void Configure(EntityTypeBuilder<Recipe> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Ingredients).IsRequired().HasMaxLength(500);
            builder.Property(x => x.MethodOfPreparation).IsRequired().HasMaxLength(1000);
            builder.Property(x => x.CreatedBy).IsRequired().HasMaxLength(50);

            builder.HasOne(x => x.recipeType).WithMany(x => x.recipes)
                .HasForeignKey(x => x.RecipeTypeId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.user).WithMany(x => x.recipes)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
