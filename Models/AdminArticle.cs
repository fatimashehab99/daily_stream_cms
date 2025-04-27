using System.ComponentModel.DataAnnotations.Schema;

namespace daily_stream_cms.Models
{
    public class AdminArticle
    {
        public int Id { get; set; }
        public int AdminId { get; set; }
        [ForeignKey("AdminId")] // Defines the relationship
        public Admin Admin { get; set; } 
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")] // Defines the relationship
        public Article Article { get; set; }
    }
}
