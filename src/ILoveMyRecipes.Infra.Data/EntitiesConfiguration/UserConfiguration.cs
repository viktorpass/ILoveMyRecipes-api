using ILoveMyRecipes.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ILoveMyRecipes.Infra.Data.EntitiesConfiguration {
    public class UserConfiguration : IEntityTypeConfiguration<User> {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Email).HasMaxLength(200).IsRequired();
            builder.Property(x => x.Name).HasMaxLength(250).IsRequired();
            builder.Property(x => x.IsAdmin).IsRequired();
        }
    }
}
