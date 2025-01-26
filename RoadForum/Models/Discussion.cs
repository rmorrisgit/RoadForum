namespace RoadForum.Models
{
    public class Discussion
    {
        public int DiscussionId { get; set; }

        // Non-nullable string properties
        public string Title { get; set; } = string.Empty;
        public string Content { get; set; } = string.Empty;
        public string ImageFilename { get; set; } = string.Empty;

        public DateTime CreateDate { get; set; }

        // Navigation property
        public List<Comment>? Comments { get; set; }


    }
}
