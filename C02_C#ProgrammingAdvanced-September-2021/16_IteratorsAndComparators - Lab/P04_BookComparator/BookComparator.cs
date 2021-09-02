namespace IteratorsAndComparators
{
    using System.Collections.Generic;
    using System.Diagnostics.CodeAnalysis;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book firstBook, [AllowNull] Book secondBook)
        {
            var compare = firstBook.Title.CompareTo(secondBook.Title);
            if (compare == 0)
            {
                compare = secondBook.Year.CompareTo(firstBook.Year);
            }

            return compare;
        }
    }
}
