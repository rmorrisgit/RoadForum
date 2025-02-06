using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Azure;

namespace RoadForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }

        // Non-nullable string properties
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string? ImageFilename { get; set; }

        // Property for file upload, not mapped in EF
        [NotMapped]
        [Display(Name = "Photograph")]
        public IFormFile? ImageFile { get; set; } // nullable!

        [Display(Name = "Date Created")]
        public DateTime CreateDate { get; set; } = DateTime.Now;


        // Navigation property
        public List<Comment>? Comments { get; set; }




    }
}
