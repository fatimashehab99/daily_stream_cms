using daily_stream_cms.Models;
using Microsoft.EntityFrameworkCore;

namespace daily_stream_cms
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

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

            // Admin Relationships
            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Role)
                .WithMany()
                .HasForeignKey(a => a.RoleId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.ProfileBlob)
                .WithMany()
                .HasForeignKey(a => a.ProfileBlobId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Admin>()
                .HasOne(a => a.Cover)
                .WithMany()
                .HasForeignKey(a => a.CoverId)
                .OnDelete(DeleteBehavior.Cascade);

            // Category Relationships
            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.NoAction);

            // Article Relationships
            modelBuilder.Entity<Article>()
                .HasOne(a => a.Category)
                .WithMany()
                .HasForeignKey(a => a.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Author)
                .WithMany()
                .HasForeignKey(a => a.CreatorId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Blob)
                .WithMany()
                .HasForeignKey(a => a.BlobId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Article>()
                .HasOne(a => a.Thumbnail)
                .WithMany()
                .HasForeignKey(a => a.ThumbnailId)
                .OnDelete(DeleteBehavior.NoAction);

            // Comment Relationships
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany()
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Article)
                .WithMany()
                .HasForeignKey(c => c.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);

            // AdminArticle Many-to-Many
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

            // ArticleKeyword Many-to-Many
            modelBuilder.Entity<ArticleKeyword>()
                .HasKey(ak => new { ak.ArticleId, ak.KeywordId });

            modelBuilder.Entity<ArticleKeyword>()
                .HasOne(ak => ak.Article)
                .WithMany(a => a.ArticleKeywords)
                .HasForeignKey(ak => ak.ArticleId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ArticleKeyword>()
                .HasOne(ak => ak.Keyword)
                .WithMany(k => k.ArticleKeywords)
                .HasForeignKey(ak => ak.KeywordId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
