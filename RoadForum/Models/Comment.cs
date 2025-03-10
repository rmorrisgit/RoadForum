using RoadForum.Data;

namespace RoadForum.Models
{
    public class Comment
    {
        public int CommentId { get; set; }

        public string Content { get; set; } = string.Empty;
        public DateTime CreateDate { get; set; }

        // Foreign key for Discussion
        public int DiscussionId { get; set; }

        // Navigation property for Discussion
        public Discussion? Discussion { get; set; }

        // Foreign key (AspNetUsers table)
        public string ApplicationUserId { get; set; } = string.Empty;

        // Navigation property
        public ApplicationUser? ApplicationUser { get; set; } // nullable!!!

    }
}
