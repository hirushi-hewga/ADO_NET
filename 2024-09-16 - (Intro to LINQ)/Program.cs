﻿using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using static System.Console;

namespace _01_Intro_to_LINQ
{
    // LINQ (Language-Integrated Query)

    // Существует несколько разновидностей LINQ:
    /*
        LINQ to Objects:        применяется для работы с массивами и коллекциями    
        LINQ to Entities:       используется при обращении к базам данных через технологию Entity Framework
        LINQ to Sql:            технология доступа к данным в MS SQL Server
        LINQ to XML:            применяется при работе с файлами XML
        LINQ to DataSet:        применяется при работе с объектом DataSet
        Parallel LINQ (PLINQ):  используется для выполнения параллельной запросов    
    */
    // Список используемых методов расширения LINQ
    /*
        Select: определяет проекцию выбранных значений

        Where: определяет фильтр выборки

        OrderBy: упорядочивает элементы по возрастанию

        OrderByDescending: упорядочивает элементы по убыванию

        ThenBy: задает дополнительные критерии для упорядочивания элементов возрастанию

        ThenByDescending: задает дополнительные критерии для упорядочивания элементов по убыванию

        Join: соединяет две коллекции по определенному признаку

        GroupBy: группирует элементы по ключу

        ToLookup: группирует элементы по ключу, при этом все элементы добавляются в словарь

        GroupJoin: выполняет одновременно соединение коллекций и группировку элементов по ключу

        Reverse: располагает элементы в обратном порядке

        All: определяет, все ли элементы коллекции удовлятворяют определенному условию

        Any: определяет, удовлетворяет хотя бы один элемент коллекции определенному условию

        Contains: определяет, содержит ли коллекция определенный элемент

        Distinct: удаляет дублирующиеся элементы из коллекции

        Except: возвращает разность двух коллекцию, то есть те элементы, которые содератся только в одной коллекции

        Union: объединяет две однородные коллекции

        Intersect: возвращает пересечение двух коллекций, то есть те элементы, которые встречаются в обоих коллекциях

        Count: подсчитывает количество элементов коллекции, которые удовлетворяют определенному условию

        Sum: подсчитывает сумму числовых значений в коллекции

        Average: подсчитывает cреднее значение числовых значений в коллекции

        Min: находит минимальное значение

        Max: находит максимальное значение

        Take: выбирает определенное количество элементов

        Skip: пропускает определенное количество элементов

        TakeWhile: возвращает цепочку элементов последовательности, до тех пор, пока условие истинно

        SkipWhile: пропускает элементы в последовательности, пока они удовлетворяют заданному условию, и затем возвращает оставшиеся элементы

        Concat: объединяет две коллекции

        Zip: объединяет две коллекции в соответствии с определенным условием

        First: выбирает первый элемент коллекции

        FirstOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию

        Single: выбирает единственный элемент коллекции, если коллекция содердит больше или меньше одного элемента, то генерируется исключение

        SingleOrDefault: выбирает первый элемент коллекции или возвращает значение по умолчанию

        ElementAt: выбирает элемент последовательности по определенному индексу

        ElementAtOrDefault: выбирает элемент коллекции по определенному индексу или возвращает значение по умолчанию, если индекс вне допустимого диапазона

        Last: выбирает последний элемент коллекции

        LastOrDefault: выбирает последний элемент коллекции или возвращает значение по умолчанию
     */
    class Program
    {
        static void Main(string[] args)
        {
            // -=-=-=-=-=-=-=-=- Синтаксис запиту -=-=-=-=-=-=-=-=-
            // результат = from item_name in source_name
            //             select result_value;

            int[] original = { 5, 34, 67, -12, 94, -42 };

            IEnumerable<int> query = from i in original
                                     select i * -1;     // відкладене завантаження (lazy loading)

            //List<int> q2 = query.ToList();           // негайне завантаження

            original[1] = 100;

            WriteLine("The array to change:");
            foreach (int item in query)                 // виконання команди
            {
                Write($"{item}\t");
            }
            WriteLine();

            // -=-=-=-=-=-=-=-=- Синтаксис методу -=-=-=-=-=-=-=-=-
            // Метод розширення
            //var result = original.Select(ConvertData);
            //var result = original.Select(delegate (int item) { return item * -1; });
            var result = original.Select(item => item * -1);

            WriteLine("\nLINQ method:");
            foreach (var item in result)
            {
                Write($"{item}\t");
            }

            System.Console.WriteLine();
        }

        static int ConvertData(int item)
        {
            return item * -1;
        }
    }
}