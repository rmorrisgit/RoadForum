using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RoadForum.Models;

namespace RoadForum.Data
{
    public class RoadForumContext : IdentityDbContext<ApplicationUser>
    {
        public RoadForumContext (DbContextOptions<RoadForumContext> options)
            : base(options)
        {
        }

        public DbSet<RoadForum.Models.Discussion> Discussion { get; set; } = default!;
        public DbSet<RoadForum.Models.Comment> Comment { get; set; } = default!;
    }
}
