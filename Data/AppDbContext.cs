using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DungeonMentor.Models;

namespace DungeonMentor.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<UserProgress> UserProgress { get; set; }

        public DbSet<TrainingResult> TrainingResults { get; set; }

    }
}
