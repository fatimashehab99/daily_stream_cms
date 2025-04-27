using System.ComponentModel.DataAnnotations;

namespace daily_stream_cms.Models
{
    public class Keyword
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public bool IsFiltered { get; set; } = false;
        public int SortNumber { get; set; } = 0;
    }
}
