namespace DungeonMentor.Models
{
    public class TrainingModule
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public List<Question> Quiz { get; set; } = new List<Question>();

        public static List<TrainingModule> GetModules()
        {
            return new List<TrainingModule>
            {
                new TrainingModule
                {
                    Id = 1,
                    Title = "Основы DnD",
                    Description = "Dungeons & Dragons (DnD) — это настольная ролевая игра, в которой игроки берут на себя роли персонажей и совместно создают воображаемые приключения под руководством Ведущего.",
                    Quiz = new List<Question>
                    {
                        new Question
                        {
                            Text = "Что такое DnD?",
                            Options = new List<string> { "Карточная игра", "Настольная ролевая игра", "Компьютерный шутер" },
                            CorrectIndex = 1
                        },
                        new Question
                        {
                            Text = "Кто такой DM (Dungeon Master)?",
                            Options = new List<string> { "Игрок", "Ведущий игры", "Создатель правил" },
                            CorrectIndex = 1
                        },
                        new Question
                        {
                            Text = "Какой основной элемент игры?",
                            Options = new List<string> { "Кубики", "Воображение", "Карты" },
                            CorrectIndex = 1
                        }
                    }
                },
                new TrainingModule
                {
                    Id = 2,
                    Title = "Боевая система",
                    Description = "Боевая система в DnD основана на инициативах, бросках кубиков и действиях. Персонажи и монстры по очереди совершают действия: атака, заклинание, перемещение и т.д.",
                    Quiz = new List<Question>
                    {
                        new Question
                        {
                            Text = "Что означает «инициатива» в бою?",
                            Options = new List<string> { "Количество здоровья", "Очередность хода", "Сила заклинания" },
                            CorrectIndex = 1
                        },
                        new Question
                        {
                            Text = "Как определяется успех атаки?",
                            Options = new List<string> { "Броском d20", "Броском d6", "Броском d100" },
                            CorrectIndex = 0
                        },
                        new Question
                        {
                            Text = "Что такое КД (Класс Доспеха)?",
                            Options = new List<string> { "Защита персонажа", "Тип доспеха", "Уровень брони" },
                            CorrectIndex = 0
                        }
                    }
                },
                new TrainingModule
                {
                    Id = 3,
                    Title = "Классы и расы",
                    Description = "Каждый персонаж в DnD принадлежит к расе (человек, эльф, дворф) и классу (воин, маг, плут и др.). Класс определяет стиль игры, способности и роль в команде.",
                    Quiz = new List<Question>
                    {
                        new Question
                        {
                            Text = "Что делает класс персонажа?",
                            Options = new List<string> { "Изменяет внешность", "Определяет способности и стиль игры", "Даёт больше золота" },
                            CorrectIndex = 1
                        },
                        new Question
                        {
                            Text = "Какая раса имеет темновидение?",
                            Options = new List<string> { "Человек", "Эльф", "Дворф" },
                            CorrectIndex = 2
                        },
                        new Question
                        {
                            Text = "Какой класс специализируется на заклинаниях?",
                            Options = new List<string> { "Воин", "Маг", "Плут" },
                            CorrectIndex = 1
                        }
                    }
                }
            };
        }
    }

    public class Question
    {
        public string Text { get; set; }
        public List<string> Options { get; set; }
        public int CorrectIndex { get; set; }
    }
}