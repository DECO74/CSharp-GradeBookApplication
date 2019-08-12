using System;
using System.Linq;
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

            if(Students.Count < 5)
            {
                throw new InvalidOperationException("Ranked Grading only available for 5 or more students.");
            }

            var threshold = (int) Math.Ceiling(Students.Count * 0.20);
            // The following is in LINQ Language
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();
            if(grades[threshold - 1] <= averageGrade)
            {
                return 'A';
            }
            else if(grades[(threshold * 2) - 1] <= averageGrade)
            {
                return 'B';
            }
            else if(grades[(threshold * 3) - 1] <= averageGrade)
            {
                return 'C';
            }
            else if(grades[(threshold * 4) - 1] <= averageGrade)
            {
                return 'D';
            }
                
                return 'F';

            // // Find Highest and Lowest Grade
            // var highestGrade = double.MinValue;
            // var lowestGrade = double.MaxValue;
            // foreach(var student in Students)
            // {
            //     highestGrade = Math.Max(student.AverageGrade, highestGrade);
            //     lowestGrade = Math.Min(student.AverageGrade, lowestGrade);
            // }
            // var rankScale = (highestGrade - lowestGrade) * 0.20;

            // foreach(var student in Students)
            // {
            //     switch(student.AverageGrade)
            //     {
            //         case var d when d >= highestGrade - rankScale:
            //             return 'A';
            //         case var d when d >= highestGrade - (2 * rankScale):
            //             return 'B';
            //         case var d when d >= highestGrade - (3 * rankScale):
            //             return 'C';
            //         case var d when d >= highestGrade - (4 * rankScale):
            //             return 'D';
            //         default:
            //             return 'F';
            //     }
            // }
        }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }

            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                System.Console.WriteLine("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }
    }
}