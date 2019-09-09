using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book, IBook
    {
        public DiskBook(string name) : base(name)
        {
        }

        public override event GradeAddedDelegate GradeAdded;

        public override void AddGrade(double grade)
        {
            using (StreamWriter sw = File.AppendText($"{Name}.txt"))
            {
                sw.WriteLine(grade);
                if (GradeAdded != null)
                {
                    GradeAdded(this, new EventArgs());
                }
            }
        }

        public override Statistics GetStatistics()
        {
            var result = new Statistics();

            using (StreamReader sr = File.OpenText($"{Name}.txt"))
            {
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var grade = double.Parse(s);
                    result.Add(grade);
                }
            }

            return result;
        }
    }
}