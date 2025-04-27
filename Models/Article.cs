using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daily_stream_cms.Models
{
    public class Article
    {
        public int Id { get; set; }
        [Required]
        public string Slug { get; set; }
        [Required]
        public string Title { get; set; }         
        public string? Description { get; set; }   
        public string? Content { get; set; }    
        public string? ImageCaption { get; set; }
        public bool IsToppedBar { get; set; } = false;
        public int SortNumber { get; set; } = 0;
        public bool IsHidden { get; set; } = false;       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")] // Defines the relationship
        public Category Category { get; set; } // Navigation property to Blob
        public bool IsFeatured { get; set; } = false;
        public int CreatorId { get; set; }
        [ForeignKey("CreatorId")] // Defines the relationship
        public Admin Author { get; set; } // Navigation property to Blob
        public bool IsSideBar { get; set; }       
        public int? BlobId { get; set; }
        [ForeignKey("BlobId")] // Defines the relationship
        public Blob Blob { get; set; } // Navigation property to Blob
        public int Views { get; set; } = 0;            
        public int ThumbnailId { get; set; }
        [ForeignKey("ThumbnailId")] // Defines the relationship
        public Blob Thumbnail { get; set; } // Navigation property to Blob
        public DateTime? ScheduledAt { get; set; }  
        public DateTime? PublishedAt { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? LastUpdated { get; set; }
        public bool IsDraft { get; set; } = false;

        public ICollection<AdminArticle> AdminArticles { get; set; }
        public ICollection<ArticleKeyword> ArticleKeywords { get; set; }
    }
}
