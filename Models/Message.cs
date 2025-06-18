using System;

namespace DungeonMentor.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string UserId { get; set; }  // ID пользователя
        public string Text { get; set; }    // Текст сообщения
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
