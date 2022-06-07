using DataAccess.Configuration;
using Domen;
using Microsoft.EntityFrameworkCore;
using System;

namespace DataAccess
{
    public class Context : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-3B9ERV0\SQLEXPRESS;Initial Catalog=BlogASP;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new CommentConfiguration());
            modelBuilder.ApplyConfiguration(new HashTagConfiguration());
            modelBuilder.ApplyConfiguration(new PostConfiguration());
            modelBuilder.ApplyConfiguration(new UseCaseLogConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());


            modelBuilder.Entity<Like>().HasKey(x => new { x.IdPost, x.idUser });
            modelBuilder.Entity<PostHashTag>().HasKey(x => new { x.IdPost, x.IdHashtag });


            modelBuilder.Entity<User>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Post>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<HashTag>().HasQueryFilter(x => !x.IsDeleted);
            modelBuilder.Entity<Comment>().HasQueryFilter(x => !x.IsDeleted);
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.Entity is Entity e)
                {
                    switch (entry.State)
                    {
                        case EntityState.Added:
                            e.CreatedAt = DateTime.UtcNow;
                            e.IsActive = true;
                            e.ModifiedAt = null;
                            e.DeletedAt = null;
                            e.IsDeleted = false;
                            break;
                        case EntityState.Modified:
                            e.ModifiedAt = DateTime.UtcNow;
                            break;
                    }
                }
            }
            return base.SaveChanges();
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<HashTag> HashTags { get; set; }
        public DbSet<Like> Likes { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostHashTag> PostHashTags { get; set; }
        public DbSet<UseCaseLog> UseCaseLogs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserUseCase> UserUseCases { get; set; }
    }
}
