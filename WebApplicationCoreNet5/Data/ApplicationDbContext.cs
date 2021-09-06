using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationCoreNet5.Entities;
using WebApplicationCoreNet5.Models;

namespace WebApplicationCoreNet5.Data
{
    // public class ApplicationDbContext : DbContext // Для пустого проекта
    public class ApplicationDbContext : IdentityDbContext<MyUser>
    {
        // WebApplicationCoreNet5.Entities.School

        public DbSet<WebApplicationCoreNet5.Entities.School.Group> Groups { get; set; }
        public DbSet<WebApplicationCoreNet5.Entities.School.Student> Students { get; set; }
        public DbSet<WebApplicationCoreNet5.Entities.School.Teacher> Teachers { get; set; }



        public DbSet<WebApplicationCoreNet5.Entities.Post> Posts { get; set; }
        public DbSet<WebApplicationCoreNet5.Entities.Category> Categories { get; set; }

        public DbSet<WebApplicationCoreNet5.Entities.Vendor> Vendors { get; set; }
        public DbSet<WebApplicationCoreNet5.Entities.Product> Products { get; set; }

        public DbSet<WebApplicationCoreNet5.Entities.Tag> Tags { get; set; }
        public DbSet<WebApplicationCoreNet5.Entities.Catalog> Catalog { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Product>()
            .HasMany(p => p.tags)
            .WithMany(t => t.products)
            .UsingEntity(j => j.ToTable("PivotProductTags"));

            /*
            .UsingEntity<Dictionary<string, object>>(
                   "PostTag",
                   j => j
                       .HasOne<Tag>()
                       .WithMany()
                       .HasForeignKey("TagId")
                       .HasConstraintName("FK_PostTag_Tags_TagId")
                       .OnDelete(DeleteBehavior.Cascade),
                   j => j
                       .HasOne<Post>()
                       .WithMany()
                       .HasForeignKey("PostId")
                       .HasConstraintName("FK_PostTag_Posts_PostId")
                       .OnDelete(DeleteBehavior.ClientCascade));
            */
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
