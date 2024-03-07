/*
    В качестве бонусного задания, можно немного разделить логику работы программы.
    Выделить класс для работы с файловой системой и класс для работы с консолью(опционально)
*/

namespace GeniusIdiotConsoleApp
{
    public class User
    {
        public string Name { get; private set; }
        public int CountRightAnswers { get; private set; }
        public string Diagnosis { get; set; }       

        public User(string Name)
        {
            this.Name = Name;
            CountRightAnswers = 0;
            Diagnosis = "Идиот";
        }
        public User(string Name, int CountRightAnswers, string Diagnosis)
        {
            this.Name = Name;
            this.CountRightAnswers = CountRightAnswers;
            this.Diagnosis = Diagnosis;
        }
        public void IncreaseRightAnswers() => CountRightAnswers++;               
    }
}
