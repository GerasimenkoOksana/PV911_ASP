using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WebUserAjax.Data.Entities;
using WebUserAjax.Data.Entities.Music;


namespace WebUserAjax.Data
{
    public class ApplicationDbContext : IdentityDbContext<ProjectUser>
    {
        #region Music
        public DbSet<Band> bands { get; set; }

        public DbSet<Disc> discs { get; set; }

        public DbSet<Label> labels { get; set; }

        public DbSet<Musician> musicians { get; set; }

        public DbSet<Role> roles { get; set; }

        protected void OnModelCreatingMusic(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musician>()
             .HasMany<Band>(m => m.bands).WithMany(b => b.musicians)
             .UsingEntity(j => j.ToTable("PivotMusiciansBand"));
        }

        #endregion

        #region School
        public DbSet<WebUserAjax.Data.Entities.School.Group> Groups { get; set; }
        public DbSet<WebUserAjax.Data.Entities.School.Student> Students { get; set; }
        public DbSet<WebUserAjax.Data.Entities.School.Teacher> Teachers { get; set; }
        #endregion

        #region Slider
        public DbSet<WebUserAjax.Data.Entities.Slider.SliderItem> SliderItem { get; set; }
        public DbSet<WebUserAjax.Data.Entities.Slider.SliderGroup> SliderGroup { get; set; }
#endregion

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            OnModelCreatingMusic(modelBuilder);
        }
    }
}
