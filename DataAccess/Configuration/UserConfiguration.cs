using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(20);

            builder.Property(x => x.LastName).IsRequired().HasMaxLength(30);

            builder.Property(x => x.Email).IsRequired();

            builder.HasMany(x => x.Comments).WithOne(y => y.User).HasForeignKey(y => y.idUser).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Likes).WithOne(y => y.User).HasForeignKey(y => y.idUser).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.UserUseCases).WithOne(y => y.User).HasForeignKey(y => y.IdUser).OnDelete(DeleteBehavior.Cascade);
        }
    }
}

