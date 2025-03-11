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
            var discussions = await _context.Discussion
                .Include(d => d.Comments) // Ensure comments are loaded
                .ToListAsync();

            return View(discussions);
        }

        public async Task<IActionResult> DiscussionDetails(int id)
        {
            var discussion = await _context.Discussion
                .Include(m => m.ApplicationUser)
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