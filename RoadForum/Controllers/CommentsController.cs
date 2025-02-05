using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RoadForum.Data;
using RoadForum.Models;

namespace RoadForum.Controllers
{
    public class CommentsController : Controller
    {
        private readonly RoadForumContext _context;

        public CommentsController(RoadForumContext context)
        {
            _context = context;
        }

        // GET: Comments
        public async Task<IActionResult> Index()
        {
            var roadForumContext = _context.Comment.Include(c => c.Discussion);
            return View(await roadForumContext.ToListAsync());
        }

        // GET: Comments/Details/5
        public async Task<IActionResult> Details(int? id)
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

        // GET: Comments/Create
        public IActionResult Create()
        {
            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "DiscussionId");
            return View();
        }

        // POST: Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId,Content,CreateDate,DiscussionId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DiscussionId"] = new SelectList(_context.Discussion, "DiscussionId", "DiscussionId", comment.DiscussionId);
            return View(comment);
        }


        private bool CommentExists(int id)
        {
            return _context.Comment.Any(e => e.CommentId == id);
        }
    }
}
