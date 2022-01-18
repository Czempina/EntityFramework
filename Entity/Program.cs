using LekcjeCSharp.Contexts;
using LekcjeCSharp.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Entity
{
    class Program
    {
        private static LekcjeCSharpContext _lekcjeCSharpContext = new LekcjeCSharpContext();
        static void Main(string[] args)
        {
            var teacher = new Teacher
            {
                MainSubject = "Matematyka"
            };

            var s1 = new Student
            {
                Name = "Szymon",
                SecondName = "Danielak",
                Age = 13
            };

            var s2 = new Student
            {
                Name = "Seba",
                SecondName = "Korki",
                Age = 25
            };

            var a1 = new Class
            {
                Name = "1A",
                Teacher = teacher
            };

            //a1.Students.Add(s1);
            //a1.Students.Add(s2);

            //_lekcjeCSharpContext.Classes.Add(a1);
            _lekcjeCSharpContext.SaveChanges();

            var students = _lekcjeCSharpContext.Classes.Where(s => s.Name == "1A").Include(s => s.Students).ToList();

            var classes = _lekcjeCSharpContext.Classes.ToList();
            Console.WriteLine("Wybierz co chcesz zrobić:\n1 - wyświetl wszystkie klasy");

            int choose  = int.Parse(Console.ReadLine());

            switch (choose)
            {
                case 1:
                    foreach (Class @class in classes)
                    {
                        Console.WriteLine(@class.Name + " " + @class.Teacher.MainSubject);
                    }
                    break;
            }

            
        }
    }
}
