using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daily_stream_cms.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Slug { get; set; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }= false;
        public int SortNumber { get; set; } = 0;
        public bool IsSlideBar { get; set; } = false;
        public bool IsToppedBar { get; set; } = false;

        public int? ParentCategoryId { get; set; } // The foreign key

        [ForeignKey("ParentCategoryId")] // Defines the relationship
        public Category ParentCategory { get; set; } // Navigation property to Blob

    }
}
