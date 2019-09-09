using System;

namespace GradeBook
{
    public class Statistics
    {
        public double Average
        {
            get
            {
                return total / count;
            }
        }
        public double High;
        public double Low;
        public char Letter
        {
            get
            {
                switch (Average)
                {
                    case var d when d >= 90.0:
                        return 'A';
                    case var d when d >= 80.0:
                        return 'B';
                    case var d when d >= 70.0:
                        return 'C';
                    case var d when d >= 60.0:
                        return 'D';
                    default:
                        return 'F';
                }
            }
        }

        private int count;
        private double total;

        public Statistics()
        {
            High = double.MinValue;
            Low = double.MaxValue;

            total = 0.0;
            count = 0;
        }

        public void Add(double number)
        {
            count++;
            total += number;

            High = Math.Max(High, number);
            Low = Math.Min(Low, number);
        }
    }
}