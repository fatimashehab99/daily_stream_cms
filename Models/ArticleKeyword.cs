using System.ComponentModel.DataAnnotations.Schema;

namespace daily_stream_cms.Models
{
    public class ArticleKeyword
    {
        public int Id { get; set; }
        public int ArticleId { get; set; }
        [ForeignKey("ArticleId")] // Defines the relationship

        public Article Article { get; set; }

        public int KeywordId { get; set; }
        [ForeignKey("KeywordId")] // Defines the relationship

        public Keyword Keyword { get; set; }
    }
}
