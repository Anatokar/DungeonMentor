namespace DungeonMentor.Models
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<string> Lessons { get; set; }

        public List<Question> Quiz { get; set; }  // ← добавили
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
    }
}
