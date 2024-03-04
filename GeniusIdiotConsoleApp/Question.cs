namespace GeniusIdiotConsoleApp
{
    public class Question //класс для вопросов
    {
        public string QuestionText { get; }
        public int Answer { get; }
        public Question(string QuestionText, int Answer)
        {
            this.QuestionText = QuestionText;
            this.Answer = Answer;            
        }
    }
}
