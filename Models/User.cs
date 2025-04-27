using System.ComponentModel.DataAnnotations;

namespace daily_stream_cms.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required] // Ensures the name is not null
        public string Name { get; set; }

        [Required] // Ensures the email is not null
        public string Email { get; set; }

        [Required] // Ensures password is not null

        public string Password { get; set; }

        public bool IsLocked { get; set; } = true;
    }
}
