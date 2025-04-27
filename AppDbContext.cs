using daily_stream_cms.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_stream_cms
{
    public class AppDbContext : DbContext
    {
        // Constructor - tell DbContext how to connect
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // 👇 Register your models (these will become Tables)
        public DbSet<Role> Roles { get; set; }
        public DbSet<Blob> Blobs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Keyword> Keywords { get; set; }
        public DbSet<Comment> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Admin and Role relationship
            modelBuilder.Entity<Admin>()
                .HasOne(u => u.Role)
                .WithMany()
                .HasForeignKey(u => u.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            // Admin and ProfileBlob relationship
            modelBuilder.Entity<Admin>()
                .HasOne(u => u.ProfileBlob)
                .WithMany()
                .HasForeignKey(u => u.ProfileBlobId)
                .OnDelete(DeleteBehavior.NoAction);

            // Admin and Cover relationship
            modelBuilder.Entity<Admin>()
                .HasOne(u => u.Cover)
                .WithMany()
                .HasForeignKey(u => u.CoverId)
                .OnDelete(DeleteBehavior.Cascade);

            // Category and ParentCategory relationship
            modelBuilder.Entity<Category>()
                .HasOne(u => u.ParentCategory)
                .WithMany()
                .HasForeignKey(u => u.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article and Category relationship
            modelBuilder.Entity<Article>()
                .HasOne(u => u.Category)
                .WithMany()
                .HasForeignKey(u => u.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            // Article and Author relationship
            modelBuilder.Entity<Article>()
                .HasOne(u => u.Author)
                .WithMany()
                .HasForeignKey(u => u.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Article and Blob relationship
            modelBuilder.Entity<Article>()
                .HasOne(u => u.Blob)
                .WithMany()
                .HasForeignKey(u => u.BlobId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article and Thumbnail relationship
            modelBuilder.Entity<Article>()
                .HasOne(u => u.Thumbnail)
                .WithMany()
                .HasForeignKey(u => u.ThumbnailId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
        .HasOne(u => u.User)
        .WithMany()
        .HasForeignKey(u => u.UserId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
        .HasOne(u => u.Article)
        .WithMany()
        .HasForeignKey(u => u.ArticleId)
        .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<AdminArticle>()
    .HasKey(aa => new { aa.AdminId, aa.ArticleId });

            modelBuilder.Entity<AdminArticle>()
                .HasOne(aa => aa.Admin)
                .WithMany(a => a.AdminArticles)
                .HasForeignKey(aa => aa.AdminId)
        .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<AdminArticle>()
                .HasOne(aa => aa.Article)
                .WithMany(a => a.AdminArticles)
                .HasForeignKey(aa => aa.ArticleId)
        .OnDelete(DeleteBehavior.NoAction);

        }
    }
}
