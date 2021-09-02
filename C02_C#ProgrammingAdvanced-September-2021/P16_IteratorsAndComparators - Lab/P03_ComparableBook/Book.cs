namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = authors;
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public IReadOnlyList<string> Authors { get; set; }

        public int CompareTo(Book other)
        {
            var compare = this.Year.CompareTo(other.Year);
            if (compare == 0)
            {
                compare = this.Title.CompareTo(other.Title);
            }

            return compare;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Title} - {this.Year}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
