using Domen;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Configuration
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(x => x.Title).IsRequired();
            builder.HasIndex(x => x.Title).IsUnique();

            builder.Property(x => x.Text).IsRequired();

            builder.Property(x => x.Image).IsRequired();


            builder.HasMany(x => x.Comments).WithOne(y => y.Post).HasForeignKey(y => y.idPost).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.Likes).WithOne(y => y.Post).HasForeignKey(y => y.IdPost).OnDelete(DeleteBehavior.Cascade);
            builder.HasMany(x => x.PostHashTags).WithOne(y => y.Post).HasForeignKey(y => y.IdPost).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
