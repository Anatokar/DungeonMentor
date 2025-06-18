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
                    Description = "Описание игры:\r\nDungeons & Dragons (DnD) — это настольная ролевая игра, где игроки создают персонажей и вместе переживают приключения в фэнтезийном мире. Игроки описывают действия своих персонажей, а Dungeon Master (DM) решает, что происходит в ответ.\r\n\r\nКлючевые моменты:\r\n\r\nDM (Dungeon Master) - ведущий игры, который описывает мир и контролирует всех неигровых персонажей\r\n\r\nОсновной элемент - воображение участников\r\n\r\nДля разрешения неочевидных ситуаций используются кубики (d4, d6, d8, d10, d12, d20)\r\n\r\nИгра не имеет строгих правил победы - цель в совместном создании истории",
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
                    Description = "Основы боя:\r\nБой в DnD происходит пошагово, с определением очередности ходов через бросок инициативы (d20 + модификатор Ловкости).\r\n\r\nМеханики:\r\n\r\nИнициатива определяет порядок ходов в раунде\r\n\r\nАтака состоит из двух бросков:\r\n\r\nБросок атаки (d20) против Класса Доспеха (КД) цели\r\n\r\nБросок урона (зависит от оружия) при успешной атаке\r\n\r\nКласс Доспеха (КД) - число, которое нужно превзойти броском атаки, чтобы попасть\r\n\r\nХарактеристики:\r\n\r\nHP (Hit Points) - здоровье персонажа\r\n\r\nAC (Armor Class) - защита от атак",
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
                    Description = "Расы:\r\n\r\nЛюди - универсальны, +1 ко всем характеристикам\r\n\r\nЭльфы - +2 к Ловкости, темновидение, иммунитет к магическому сну\r\n\r\nДворфы - +2 к Телосложению, сопротивление яду, но нет темновидения\r\n\r\nКлассы:\r\n\r\nВоин - специалист по оружию, высокая защита\r\n\r\nМаг - заклинатель, слабая защита, но мощные атаки\r\n\r\nПлут - мастер скрытности и критических ударов\r\n\r\nЖрец - сочетание боевых навыков и божественной магии\r\n\r\nОсобенности:\r\n\r\nКласс определяет:\r\n\r\nХиты (HP)\r\n\r\nВладение оружием и доспехами\r\n\r\nКлассовые способности\r\n\r\nДоступные заклинания (если есть)\r\n\r\nРаса даёт:\r\n\r\nБонусы к характеристикам\r\n\r\nРасовые способности\r\n\r\nРазмер и скорость передвижения",
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
                            Text = "Какая раса не имеет темновидение?",
                            Options = new List<string> { "Человек", "Эльф", "Дворф" },
                            CorrectIndex = 0
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