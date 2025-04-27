using System.ComponentModel.DataAnnotations;

namespace daily_stream_cms.Models
{
    public class Role
    {
        public int Id { get; set; }
        [Required]
        public  string Name { get; set; }
        public int SortNumber { get; set; } = 0;
        public bool IsFilter { get; set; } = false;//note by default it will be created as false but just for clarifying 
    }
}
