/*
    В качестве бонусного задания, можно немного разделить логику работы программы.
    Выделить класс для работы с файловой системой и класс для работы с консолью(опционально)
*/

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static void Main()
        {
            var user = ConsoleManager.CreateUser();    
            //цикл прохождения теста
            while (true)
            {
                ConsoleManager.StartTest(user);
                ConsoleManager.ShowResultsQuestion();
                ConsoleManager.StartTestRepeatQuestion();
                if (!ConsoleManager.GetUserYesOrNoAnswer()) break;               
            }
        }
    }
}
