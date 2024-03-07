using System;
using System.Linq;
using System.Runtime.Remoting.Messaging;

/*
    В качестве бонусного задания, можно немного разделить логику работы программы.
    Выделить класс для работы с файловой системой и класс для работы с консолью(опционально)
*/

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static string GetDiagnosis(int countRigthAnswers, int countQuestions) //Доп. задача 1 - изменена функция
        {
            var diagnoses = new string[6];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            //Доп. задача №1: правило постановки диагноза
            var percentRightAnswers = 100 * countRigthAnswers / countQuestions;
            if (percentRightAnswers < 10) return diagnoses[0];
            if (percentRightAnswers < 30) return diagnoses[1];
            if (percentRightAnswers < 50) return diagnoses[2];
            if (percentRightAnswers < 70) return diagnoses[3];
            if (percentRightAnswers < 90) return diagnoses[4];
            return diagnoses[5];
        } 
        static void StartTest(User user)
        {
            Console.Clear(); //в случае повтора теста решил очистить консоль, чтобы нельзя было смотреть на введенные ответы.)

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

            user.Diagnosis = GetDiagnosis(user.CountRightAnswers, questions.Count());

            Console.WriteLine($"Пользователь {user.Name}");
            Console.WriteLine($"Количество правильных ответов: {user.CountRightAnswers}");
            Console.WriteLine($"Ваш диагноз: {user.Diagnosis}");

            UserStorage.SaveUsersResult(user); //сохранение результатов в отдельный файл
        }
        /// <summary>
        /// Возвращает булевое значение о повторе теста
        /// </summary>
        static bool GetUserRepeatAnswer()
        {
            var testRepeat = true; //переменная для повтора теста
            while (true) //цикл вопроса о повторении
            {
                var userRepeatAnswer = Console.ReadLine().ToLower();
                if (userRepeatAnswer != "да" && userRepeatAnswer != "нет")
                {
                    Console.WriteLine("Неверные входные данные (Введите да/нет)");
                    continue;
                }
                if (userRepeatAnswer == "нет") testRepeat = false;
                break;
            }
            return testRepeat;
        }

        static void Main()
        {
            Console.WriteLine("Введите имя пользователя:");
            var user = new User(Console.ReadLine());            
            //цикл прохождения теста
            while (true)
            {
                StartTest(user);
                Console.WriteLine("\nХотите посмотреть таблицу результатов? (Введите да/нет)");
                if (GetUserRepeatAnswer())
                {
                    ResultTable.ShowResults();
                    Console.WriteLine("\nХотите очистить таблицу результатов? (Введите да/нет)");
                    if(GetUserRepeatAnswer()) ResultTable.ClearResults();                    
                }

                Console.WriteLine("\nТест завершён. Хотите пройти тест заново?(Введите да/нет)");
                if (!GetUserRepeatAnswer()) break;               
            }
        }
    }
}
