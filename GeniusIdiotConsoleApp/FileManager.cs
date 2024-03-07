using System.IO;

/*
    В качестве бонусного задания, можно немного разделить логику работы программы.
    Выделить класс для работы с файловой системой и класс для работы с консолью(опционально)
*/

namespace GeniusIdiotConsoleApp
{
    public static class FileManager
    {
        public static void Append(string filePath, string content)
        {
            using (var sw = new StreamWriter(filePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(content);
            }
        }
        public static string GetContent(string filePath)
        {
            return File.ReadAllText(filePath, System.Text.Encoding.Default);
        }
        public static void Clear(string filePath) => File.WriteAllText(filePath, string.Empty);
    }
}
