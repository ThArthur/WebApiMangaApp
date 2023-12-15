using Flunt.Notifications;
using MangaList.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApiMangaApp.Model;

namespace WebApiMangaApp.Data
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public DbSet<Manga> Mangas { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryManga> CategoryMangas { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Ignore<Notification>();

            modelBuilder.Entity<CategoryManga>()
            .HasKey(cm => new { cm.MangaId, cm.CategoryId });

            modelBuilder.Entity<CategoryManga>()
                .HasOne(m => m.Category)
                .WithMany(cm => cm.CategoryMangas)
                .HasForeignKey(cm => cm.MangaId);

            modelBuilder.Entity<CategoryManga>()
                .HasOne(c => c.Manga)
                .WithMany(cm => cm.CategoryMangas)
                .HasForeignKey(cm => cm.CategoryId);
            
        }
    }
}
