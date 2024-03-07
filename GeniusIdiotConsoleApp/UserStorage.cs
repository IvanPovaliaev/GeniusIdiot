using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GeniusIdiotConsoleApp
{
    /// <summary>
    /// Статический класс для данных пользователей
    /// </summary>
    public static class UserStorage
    {
        private static string filePath { get; } = @".\TestResults\TestResults.txt";
        public static IEnumerable<User> GetUsersResults()
        {
            var lines = FileManager.GetContent(filePath).Split(new string[] {"\n"}, StringSplitOptions.RemoveEmptyEntries);
            foreach (var userResult in lines)
            {
                var userInfo = userResult.Split(new string[] { "|||||" }, StringSplitOptions.RemoveEmptyEntries);
                yield return new User(userInfo[0], int.Parse(userInfo[1]), userInfo[2]);
            }
        }
        public static void SaveUsersResult(User user)
        {
            var result = $"{user.Name}|||||{user.CountRightAnswers}|||||{user.Diagnosis}";
            FileManager.Append(filePath, result);
        }
        public static void ClearUsersResults()
        {
            FileManager.Clear(filePath);
        }
    }
}
