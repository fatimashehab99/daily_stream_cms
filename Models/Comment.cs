using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daily_stream_cms.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }
        public bool IsApproved { get; set; } = false;
        public int ArticleId { get; set; }

        [ForeignKey("ArticleId")] // Defines the relationship
        public Article Article { get; set; } 
        public int UserId { get; set; }
        [ForeignKey("UserId")] // Defines the relationship
        public User User { get; set; }


    }
}
