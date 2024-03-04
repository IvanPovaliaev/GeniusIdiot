using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static List<Question> GetQuestions(int countQuestions)
        {
            var questions = new List<Question>();
            questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
            questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
            questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
            questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
            return questions;
        }
        static string[] GetDiagnoses(int countDiagnoses)
        {
            var diagnoses = new string[countDiagnoses];
            diagnoses[0] = "Идиот";
            diagnoses[1] = "Кретин";
            diagnoses[2] = "Дурак";
            diagnoses[3] = "Нормальный";
            diagnoses[4] = "Талант";
            diagnoses[5] = "Гений";
            return diagnoses;
        }

        static void Main()
        {
            Console.WriteLine("Введите имя пользователя:");
            string username = Console.ReadLine();

            int countQuestions = 5; //количество вопросов
            Random random = new Random();
            bool testRepeat = true; //переменная для повтора теста
            
            //цикл прохождения теста
            while (testRepeat)
            {
                var questions = GetQuestions(countQuestions).Shuffle().ToList(); //Сразу перемешиваем список вопросов            

                int countRigthAnswers = 0;

                for (int i = 0; i < countQuestions; i++)
                {
                    Console.WriteLine($"Вопрос №{i + 1}");
                    Console.WriteLine($"{questions[i].QuestionText}");
                    int userAnswer = int.Parse(Console.ReadLine());
                    if (userAnswer == questions[i].Answer) countRigthAnswers++;
                }

                var diagnoses = GetDiagnoses(countQuestions + 1);

                Console.WriteLine($"Пользователь {username}");
                Console.WriteLine($"Количество правильных ответов: {countRigthAnswers}");
                Console.WriteLine($"Ваш диагноз: {diagnoses[countRigthAnswers]}");
                Console.WriteLine("\nТест завершён. Хотите пройти тест заново?(Введите да/нет)");
                
                //цикл вопроса о повторении
                while (true) 
                {
                    string userRepeatAnswer = Console.ReadLine().ToLower();
                    if (userRepeatAnswer != "да" && userRepeatAnswer != "нет")
                    {
                        Console.WriteLine("Неверные входные данные (Введите да/нет)");
                        continue;
                    }
                    if (userRepeatAnswer == "нет") testRepeat = false;
                    else Console.Clear(); //в случае повтора теста решил очистить консоль, чтобы нельзя было смотреть на введенные ответы.)
                    break;
                }
            }
        }
    }
}
