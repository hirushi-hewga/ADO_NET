using static System.Console;

namespace _2024_09_16__LINQ_to_SQL_
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1

            /*
            int[] arr = { 23, 46, 93, -2, 54, -10, -34, 90, 65, -32 };

            IEnumerable<int> list1 = from i in arr
                                     where i > 0
                                     orderby i
                                     select i;

            var list2 = arr.Where(i => i > 0).OrderBy(i => i);

            Write("List 1 : ");
            foreach (var i in list1) Write($"{i} ");

            Write("\nList 2 : ");
            foreach (var i in list2) Write($"{i} ");
            */

            #endregion

            #region 2

            /*
            int[] arr = { 23, 46, 93, -2, 54, -10, -34, 90, 65, -32 };

            var count1 = (from i in arr
                          where i >= 10
                          select i).Count();

            var avg1 = (from i in arr
                        where i >= 10
                        select i).Average();

            var count2 = arr.Where(i => i >= 10).Count();

            var avg2 = arr.Where(i => i >= 10).Average();

            WriteLine($"Count 1 : {count1}");
            WriteLine($"Average 1 : {avg1}");
            WriteLine($"Count 2 : {count2}");
            WriteLine($"Average 2 : {avg2}");
            */

            #endregion

            #region 3

            /*
            int[] arr = { 2010, 2011, 2012, 2013, 2014, 2015, 2016, 
                2017, 2018, 2019, 2020, 2021, 2022, 2023, 2024 };

            IEnumerable<int> list1 = from i in arr
                                     where i % 4 == 0
                                     orderby i
                                     select i;

            var list2 = arr.Where(i => i % 4 == 0).OrderBy(i => i);

            Write("List 1 : ");
            foreach (var i in list1) Write($"{i} ");

            Write("\nList 2 : ");
            foreach (var i in list2) Write($"{i} ");
            */

            #endregion

            #region 4

            /*
            int[] arr = { 23, 46, 93, -2, 54, -10, -34, 90, 65, -32 };

            var max1 = (from i in arr
                        where i % 2 == 0
                        orderby i
                        select i).LastOrDefault();
            
            var max2 = arr.Where(i => i % 2 == 0).OrderByDescending(i => i).FirstOrDefault();

            WriteLine($"Max 1 : {max1}");
            WriteLine($"Max 2 : {max2}");
            */

            #endregion

            #region 5

            /*
            string[] words = { "Apple", "Board", "Event", "Souls", "Spin", "Fruit" };

            IEnumerable<string> list1 = from i in words
                                         select string.Concat(i + "!!!");

            var list2 = words.Select(i => string.Concat(i + "!!!"));

            Write("List 1 : ");
            foreach (var i in list1) Write($"{i} ");

            Write("\nList 2 : ");
            foreach (var i in list2) Write($"{i} ");
            */

            #endregion

            #region 6

            /*
            string[] words = { "apple", "sport", "event", "souls", "spin", "fruit" };
            char symbol = 's';

            IEnumerable<string> list1 = from i in words
                                        where i.Contains(symbol)
                                        select i;

            var list2 = words.Where(i => i.Contains(symbol));

            Write("List 1 : ");
            foreach (var i in list1) Write($"{i} ");

            Write("\nList 2 : ");
            foreach (var i in list2) Write($"{i} ");
            */

            #endregion

            #region 7

            /*
            string[] words = { "apple", "sport", "souls", "spin", "fruit", "friend", "boy", "son" };

            IEnumerable<IGrouping<int, string>> list1 = from i in words
                                                     group i by i.Length;

            var list2 = words.GroupBy(i => i.Length);

            WriteLine("List 1 : ");
            foreach (IGrouping<int, string> group in list1)
            {
                Write($"Key: {group.Key}\nValue:");

                foreach (string item in group)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }

            WriteLine("\nList 2 : ");
            foreach (IGrouping<int, string> group in list2)
            {
                Write($"Key: {group.Key}\nValue:");

                foreach (string item in group)
                {
                    Write($"\t{item}");
                }
                WriteLine();
            }
            */

            #endregion
        }
    }
}