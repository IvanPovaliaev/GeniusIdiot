using System;
using System.Linq;

namespace GeniusIdiotConsoleApp
{
    /// <summary>
    /// Статический класс для работы с консолью
    /// </summary>
    public static class ConsoleManager
    {
        public static User CreateUser()
        {
            Console.WriteLine("Введите имя пользователя:");
            return new User(Console.ReadLine());
        }
        public static void StartTest(User user)
        {
            Console.Clear(); //в случае повтора теста решил очистить консоль, чтобы нельзя было смотреть на введенные ответы.)
            user.ResetResults(); //сброс правильных ответов и диагноза при повторном прохождении
            
            var questions = QuestionsStorage.GetQuestions().Shuffle().ToList(); //Сразу перемешиваем список вопросов          

            for (int i = 0; i < questions.Count(); i++)
            {
                Console.WriteLine($"Вопрос №{i + 1}");
                Console.WriteLine($"{questions[i].QuestionText}");
                var userAnswer = Console.ReadLine();
                if (int.TryParse(userAnswer, out _)) //добавил для случая некорректного ввода ответа
                {
                    if (int.Parse(userAnswer) == questions[i].Answer) user.IncreaseRightAnswers();
                }
            }

            user.Diagnosis = Program.GetDiagnosis(user.CountRightAnswers, questions.Count());

            Console.WriteLine($"Пользователь {user.Name}");
            Console.WriteLine($"Количество правильных ответов: {user.CountRightAnswers}");
            Console.WriteLine($"Ваш диагноз: {user.Diagnosis}");

            UserStorage.SaveUsersResult(user); //сохранение результатов в отдельный файл
        }
        public static bool GetUserYesOrNoAnswer()
        {
            while (true) //зацикливаем вопрос
            {
                var userAnswer = Console.ReadLine().ToLower();
                if (userAnswer != "да" && userAnswer != "нет")
                {
                    Console.WriteLine("Неверные входные данные (Введите да/нет)");
                    continue;
                }
                if (userAnswer == "нет") return false;
                break;
            }
            return true;
        }
        public static void ShowResults()
        {
            Console.WriteLine($"|| {"ФИО",-15} || {"Кол-во правильных ответов",-30} || {"Диагноз",-20}");
            var users = UserStorage.GetUsersResults();

            foreach (var user in users)
            {
                Console.WriteLine($"|| {user.Name,-15} || {user.CountRightAnswers,-30} || {user.Diagnosis,-20}");
            }
        }
    }
}
