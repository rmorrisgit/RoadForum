using RoadForum.Data;

namespace RoadForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        // Non-nullable string property
        public string Content { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        // Foreign key property
        public int DiscussionId { get; set; }

        // Non-nullable navigation property for the related discussion
        public Discussion? Discussion { get; set; }
        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;

        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!

    }
}
