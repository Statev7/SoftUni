namespace IteratorsAndComparators
{
    using System.Collections.Generic;
    using System.Text;

    public class Book
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

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.Title} - {this.Year}");

            return sb.ToString().TrimEnd(); 
        }
    }
}
