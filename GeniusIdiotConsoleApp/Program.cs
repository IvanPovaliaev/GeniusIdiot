using System;
/*
    В качестве бонусного задания, можно немного разделить логику работы программы.
    Выделить класс для работы с файловой системой и класс для работы с консолью(опционально)
*/
namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        public static string GetDiagnosis(int countRigthAnswers, int countQuestions)
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
        static void Main()
        {
            var user = ConsoleManager.CreateUser();    
            //цикл прохождения теста
            while (true)
            {
                ConsoleManager.StartTest(user);
                Console.WriteLine("\nХотите посмотреть таблицу результатов? (Введите да/нет)");

                if (ConsoleManager.GetUserYesOrNoAnswer())
                {
                    Console.Clear();
                    ConsoleManager.ShowResults();

                    Console.WriteLine("\nХотите очистить таблицу результатов? (Введите да/нет)");
                    if (ConsoleManager.GetUserYesOrNoAnswer())
                    {
                        UserStorage.ClearUsersResults();
                        Console.Clear();
                    }
                }

                Console.WriteLine("\nТест завершён. Хотите пройти тест заново?(Введите да/нет)");
                if (!ConsoleManager.GetUserYesOrNoAnswer()) break;               
            }
        }
    }
}
