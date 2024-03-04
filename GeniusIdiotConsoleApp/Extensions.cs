using System;
using System.Collections.Generic;
using System.Linq;

namespace GeniusIdiotConsoleApp
{
    public static class Extensions
    {
        /// <summary>
        /// Рандомно перемешивает элементы текущей коллекции
        /// </summary>
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> array)
        {
            var inputList = array.ToList();
            var outputList = new List<T>();

            //Цикл для перемешивания
            while (inputList.Count > 0)
            {
                var random = new Random();
                int randomIndex = random.Next(0, inputList.Count);
                outputList.Add(inputList[randomIndex]);
                inputList.RemoveAt(randomIndex);
            }

            return outputList;
        }
    }
}
