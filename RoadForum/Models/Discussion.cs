using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Azure;
using RoadForum.Data;

namespace RoadForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? ImageFilename { get; set; }

        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; }

        [Display(Name = "Date Created")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        // Initialize Comments as an empty list to avoid null issues
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;

        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!

    }

}
