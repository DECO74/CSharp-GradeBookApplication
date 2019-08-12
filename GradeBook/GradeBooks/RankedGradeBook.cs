using System;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            Type = GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            int rankDivider = (Students.Count * 20) / 100; 

            if(Students.Count <= 5)
            {
                throw new InvalidOperationException("Ranked Grading only available for 5 or more students.");
            }

            var threshold = (int)Math.Ceiling(Students.Count * 0.20);
            // The following is in LINQ 
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            // Find Highest and Lowest Grade
            var highestGrade = double.MinValue;
            var lowestGrade = double.MaxValue;
            foreach(var student in Students)
            {
                highestGrade = Math.Max(student.AverageGrade, highestGrade);
                lowestGrade = Math.Min(student.AverageGrade, lowestGrade);
            }
            var rankScale = (highestGrade - lowestGrade) * 0.20;


            foreach(var student in Students)
            {
                switch(student.AverageGrade)
                {
                    case var d when d >= highestGrade - rankScale:
                        return 'A';
                    case var d when d >= highestGrade - (2 * rankScale):
                        return 'B';
                    case var d when d >= highestGrade - (3 * rankScale):
                        return 'C';
                    case var d when d >= highestGrade - (4 * rankScale):
                        return 'D';
                    default:
                        return 'F';
                }
            }
            return 'F';
        }
    }
}