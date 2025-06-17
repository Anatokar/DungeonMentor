// Models/ApplicationUser.cs
using Microsoft.AspNetCore.Identity;

namespace DungeonMentor.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<UserProgress> Progresses { get; set; } = new List<UserProgress>();
    }
}
