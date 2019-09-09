using System;
using System.Collections.Generic;

namespace GradeBook
{
    public class InMemoryBook : Book
    {
        public override event GradeAddedDelegate GradeAdded;
        public List<double> Grades;

        public InMemoryBook(string name) : base(name)
        {
            Grades = new List<double>();
        }

        public void AddGrade(char letter)
        {
            switch (letter)
            {
                case 'A':
                    AddGrade(90);
                    break;
                case 'B':
                    AddGrade(80);
                    break;
                case 'C':
                    AddGrade(70);
                    break;
                default:
                    AddGrade(0);
                    break;
            }
        }

        public override void AddGrade(double grade)
        {
            if (grade <= 100 && grade >= 0)
            {
                Grades.Add(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }


        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            foreach (var g in Grades)
            {
                result.Add(g);
            }

            return result;
        }
    }
}