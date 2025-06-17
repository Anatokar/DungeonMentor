// Models/UserProgress.cs
namespace DungeonMentor.Models
{
    public class UserProgress
    {
        public int Id { get; set; }
        public string UserId { get; set; } = null!;
        public ApplicationUser User { get; set; } = null!;
        public int ModuleId { get; set; }
        public bool Completed { get; set; }
    }
}
