using System.Collections.Generic;

/*
    В качестве бонусного задания, можно немного разделить логику работы программы.
    Выделить класс для работы с файловой системой и класс для работы с консолью(опционально)
*/

namespace GeniusIdiotConsoleApp
{
    public static class QuestionsStorage
    {
        public static List<Question> GetQuestions()
        {
            var questions = new List<Question>();
            questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
            questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
            questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
            questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
            return questions;
        }
    }
}
