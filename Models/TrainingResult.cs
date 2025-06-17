using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DungeonMentor.Models
{
    public class TrainingResult
    {
        public int Id { get; set; }

        [Required]
        public string ModuleName { get; set; } = string.Empty;

        public int Score { get; set; }

        public DateTime PassedAt { get; set; } = DateTime.UtcNow;

        public string? UserId { get; set; }

        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
    }
}
