using System;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Vladimir's Gradebook");
            book.AddGrade(49.5);
            book.AddGrade(90.1);
            book.AddGrade(6.1);
            book.AddGrade(5.0);

            var stats = book.GetStatistics();

            Console.WriteLine($"The lowest grade is {stats.Low}");
            Console.WriteLine($"The highest grade is {stats.High}");
            Console.WriteLine($"The average grade is {stats.Average}");
        }
    }
}
