using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using RoadForum.Models;

namespace RoadForum.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // Create a hardcoded list of discussions
            List<Discussion> discussions = new List<Discussion>
            {
                new Discussion
                {
                    DiscussionId = 1,
                    Title = "General Discussion",
                    Content = "This is a general discussion topic.",
                    ImageFilename = "general.jpg",
                    CreateDate = DateTime.Now
                },
                new Discussion
                {
                    DiscussionId = 2,
                    Title = "Tech Talk",
                    Content = "Let's discuss the latest tech trends.",
                    ImageFilename = "tech.jpg",
                    CreateDate = DateTime.Now
                },
                new Discussion
                {
                    DiscussionId = 3,
                    Title = "Sports Chat",
                    Content = "Who will win the championship?",
                    ImageFilename = "sports.jpg",
                    CreateDate = DateTime.Now
                }
            };

            // Pass the list to the view
            return View(discussions);
        }

        public IActionResult DiscussionDetails(int id)
        {
            // Simulate fetching a discussion by ID
            var discussions = new List<Discussion>
            {
                new Discussion
                {
                    DiscussionId = 1,
                    Title = "General Discussion",
                    Content = "This is a general discussion topic.",
                    ImageFilename = "general.jpg",
                    CreateDate = DateTime.Now
                },
                new Discussion
                {
                    DiscussionId = 2,
                    Title = "Tech Talk",
                    Content = "Let's discuss the latest tech trends.",
                    ImageFilename = "tech.jpg",
                    CreateDate = DateTime.Now
                },
                new Discussion
                {
                    DiscussionId = 3,
                    Title = "Sports Chat",
                    Content = "Who will win the championship?",
                    ImageFilename = "sports.jpg",
                    CreateDate = DateTime.Now
                }
            };

            // Find the discussion with the matching ID
            var discussion = discussions.Find(d => d.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }
    }
}
