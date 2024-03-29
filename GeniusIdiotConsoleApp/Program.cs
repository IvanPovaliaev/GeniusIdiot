﻿using System;
using System.Collections.Generic;
using System.Linq;

/*
    Прочитать про var и использовать в проекте.
*/

namespace GeniusIdiotConsoleApp
{
    internal class Program
    {
        static List<Question> GetQuestions()
        {
            var questions = new List<Question>();
            questions.Add(new Question("Сколько будет два плюс два умноженное на два?", 6));
            questions.Add(new Question("Бревно нужно распилить на 10 частей. Сколько распилов нужно сделать?", 9));
            questions.Add(new Question("На двух руках 10 пальцев. Сколько пальцев на 5 руках?", 25));
            questions.Add(new Question("Укол делают каждые полчаса. Сколько нужно минут, чтобы сделать три укола?", 60));
            questions.Add(new Question("Пять свечей горело, две потухли. Сколько свечей осталось?", 2));
            return questions;
        }
        static string GetDiagnosis(int countRigthAnswers, int countQuestions) //Доп. задача 1 - изменена функция
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
        static void StartTest(string username)
        {
            Console.Clear(); //в случае повтора теста решил очистить консоль, чтобы нельзя было смотреть на введенные ответы.)
            var questions = GetQuestions().Shuffle().ToList(); //Сразу перемешиваем список вопросов          
            var countRigthAnswers = 0;
            var countQuestions = questions.Count(); //Для доп. задачи определяем количество вопросов

            for (int i = 0; i < countQuestions; i++)
            {
                Console.WriteLine($"Вопрос №{i + 1}");
                Console.WriteLine($"{questions[i].QuestionText}");
                var userAnswer = Console.ReadLine();
                if (int.TryParse(userAnswer, out _)) //добавил для случая некорректного ввода ответа
                {
                    if (int.Parse(userAnswer) == questions[i].Answer) countRigthAnswers++;
                }
            }

            var diagnosis = GetDiagnosis(countRigthAnswers, countQuestions);

            Console.WriteLine($"Пользователь {username}");
            Console.WriteLine($"Количество правильных ответов: {countRigthAnswers}");
            Console.WriteLine($"Ваш диагноз: {diagnosis}");

            ResultTable.SaveResult(username, countRigthAnswers, diagnosis); //сохранение результатов в отдельный файл
        }
        /// <summary>
        /// Возвращает булевое значение о повторе теста
        /// </summary>
        static bool GetUserRepeatAnswer()
        {
            var testRepeat = true; //переменная для повтора теста
            while (true) //цикл вопроса о повторении
            {
                var userRepeatAnswer = Console.ReadLine().ToLower();
                if (userRepeatAnswer != "да" && userRepeatAnswer != "нет")
                {
                    Console.WriteLine("Неверные входные данные (Введите да/нет)");
                    continue;
                }
                if (userRepeatAnswer == "нет") testRepeat = false;
                break;
            }
            return testRepeat;
        }

        static void Main()
        {
            Console.WriteLine("Введите имя пользователя:");
            var username = Console.ReadLine();
            
            //цикл прохождения теста
            while (true)
            {
                StartTest(username);
                Console.WriteLine("\nХотите посмотреть таблицу результатов? (Введите да/нет)");
                if (GetUserRepeatAnswer())
                {
                    ResultTable.ShowResults();
                    Console.WriteLine("\nХотите очистить таблицу результатов? (Введите да/нет)");
                    if(GetUserRepeatAnswer()) ResultTable.ClearResults();                    
                }

                Console.WriteLine("\nТест завершён. Хотите пройти тест заново?(Введите да/нет)");
                if (!GetUserRepeatAnswer()) break;               
            }
        }
    }
}
