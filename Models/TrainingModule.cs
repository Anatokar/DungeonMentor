namespace DungeonMentor.Models
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Lessons { get; set; }
    }
}