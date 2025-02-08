using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoadForum.Data; // Assuming this is your DbContext namespace
using RoadForum.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RoadForum.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoadForumContext _context;

        public HomeController(RoadForumContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            // Fetch discussions from the database
            var discussions = await _context.Discussion.ToListAsync();

            // Pass the list to the view
            return View(discussions);
        }
        public async Task<IActionResult> DiscussionDetails(int id)
        {
            var discussion = await _context.Discussion
                .Include(d => d.Comments) // Ensure comments are loaded
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }

        public async Task<IActionResult> GetDiscussion(int id)
        {
            var discussion = await _context.Discussion
                .Include(d => d.Comments) // Ensure comments are loaded
                .FirstOrDefaultAsync(m => m.DiscussionId == id);

            if (discussion == null)
            {
                return NotFound();
            }

            return View(discussion);
        }





    }
}