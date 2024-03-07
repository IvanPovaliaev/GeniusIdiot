using System.IO;

namespace GeniusIdiotConsoleApp
{
    /// <summary>
    /// Статический класс для работы с файловой системой
    /// </summary>
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
