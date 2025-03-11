using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoadForum.Data;
using RoadForum.Models;

namespace RoadForum.Controllers
{
    // only logged in users have access
    [Authorize]
    public class CommentsController : Controller
    {
        private readonly RoadForumContext _context;
        private readonly UserManager<ApplicationUser> _userManager;


        public CommentsController(RoadForumContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;

        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var roadForumContext = _context.Comment
                .Include(c => c.Discussion)
                .Include(c => c.ApplicationUser); // Include the ApplicationUser to access user info

            return View(await roadForumContext.ToListAsync());
        }

        public IActionResult Create(int discussionId)
        {
            if (discussionId == 0)
            {
                return NotFound(); // Ensure a valid ID is passed
            }

            // Get the logged-in user's name
            var userName = _userManager.GetUserName(User);

            // Initialize a new comment with the current date and the discussion ID
            var comment = new Comment
            {
                DiscussionId = discussionId,
                CreateDate = DateTime.Now
            };

            // Pass the user name to the view
            ViewData["UserName"] = userName;

            return View(comment); // Render the Create view
        }

        // POST: Comments/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Content,DiscussionId")] Comment comment)
        {
            comment.CreateDate = DateTime.Now;

            //Set the user id of the person logged in 
            comment.ApplicationUserId = _userManager.GetUserId(User);  // Set the logged-in user's ID

            if (ModelState.IsValid)
            {
                // Automatically set the CreateDate when saving the comment

                _context.Add(comment);
                await _context.SaveChangesAsync();

                // Redirect to the DiscussionDetails view in the Home controller
                return RedirectToAction("DiscussionDetails", "Home", new { id = comment.DiscussionId });
            }

            // Reload the discussion dropdown in case of an error
            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "DiscussionId", comment.DiscussionId);
            return View(comment);
        }



        // GET: Comments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comment
                .Include(c => c.Discussion)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        // POST: Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comment.FindAsync(id);
            if (comment != null)
            {
                _context.Comment.Remove(comment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }
    }
}
