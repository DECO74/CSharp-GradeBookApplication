using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class StandardGradeBook : BaseGradeBook
    {
        public StandardGradeBook(string name, bool isWeigthed) : base(name, isWeigthed)
        {
            Type = GradeBookType.Standard;
        }
    }
}