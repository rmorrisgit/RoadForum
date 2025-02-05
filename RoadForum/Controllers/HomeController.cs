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

            };

            // Pass the list to the view
            return View(discussions);
        }

        public IActionResult DiscussionDetails(int id)
        {
            // Simulate fetching a discussion by ID
            var discussions = new List<Discussion>
            {
  
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
