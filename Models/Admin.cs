using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace daily_stream_cms.Models
{
    public class Admin
    {
        public int Id { get; set; }

        [Required] // Ensures the name is not null
        public string Name { get; set; }

        [Required] // Ensures the email is not null
        public string Email { get; set; }

        [Required] // Ensures the phone is not null
        public string Phone { get; set; }

        public string? TwitterAccount { get; set; }

        [Required] // Ensures password is not null

        public string Password { get; set; }

        public bool IsLocked { get; set; } = false;

        [Required]
        public int RoleId { get; set; } // The foreign key

        [ForeignKey("RoleId")] // Defines the relationship
        public Role Role { get; set; } // Navigation property to Role

        public int ProfileBlobId { get; set; } // The foreign key

        [ForeignKey("ProfileBlobId")] // Defines the relationship
        public Blob ProfileBlob { get; set; } // Navigation property to Blob

        public int CoverId { get; set; } // The foreign key

        [ForeignKey("CoverId")] // Defines the relationship
        public Blob Cover { get; set; } // Navigation property to Blob

        public ICollection<AdminArticle> AdminArticles { get; set; }

    }
}
