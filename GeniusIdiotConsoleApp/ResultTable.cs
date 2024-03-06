using System;
using System.IO;

namespace GeniusIdiotConsoleApp
{
    public static class ResultTable
    {
        private static string resultDirPath { get; } = @".\TestResults";
        private static  DirectoryInfo resultDirectory { get; } = new DirectoryInfo(resultDirPath);
        private static string resultFileName { get; } = @"TestResults.txt";
        private static string resultFilePath { get; } = resultDirPath + @"\" + resultFileName;
        private static void CreateResults()
        {
            if (!resultDirectory.Exists) resultDirectory.Create();
        }

        public static void SaveResult(string username, int countRigthAnswers, string diagnosis)
        {
            CreateResults();
            string result = $"{username}|||||{countRigthAnswers}|||||{diagnosis}";
            using (StreamWriter sw = new StreamWriter(resultFilePath, true, System.Text.Encoding.Default))
            {
                sw.WriteLine(result);
            }
        }
        public static void ShowResults()
        {
            CreateResults();
            Console.Clear();
            Console.WriteLine($"|| {"ФИО",-15} || {"Кол-во правильных ответов",-30} || {"Диагноз",-20}");
            var lines = File.ReadLines(resultFilePath, System.Text.Encoding.Default);

            foreach (var line in lines)
            {
                var userResult = line.Split(new string[] { "|||||" }, StringSplitOptions.RemoveEmptyEntries);
                Console.WriteLine($"|| {userResult[0],-15} || {userResult[1],-30} || {userResult[2],-20}");
            }
        }
        public static void ClearResults() => File.Delete(resultFilePath);

    }
}
