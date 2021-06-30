namespace P02_Articles.Models
{
    public class Article
    {
        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public string Title { get; private set; }

        public string Content { get; private set; }

        public string Author { get; private set; }

        public void Edit(string newContent)
        {
            this.Content = newContent;
        }

        public void ChangeAuthor(string newAuthor)
        {
            this.Author = newAuthor;
        }

        public void Rename(string newTitle)
        {
            this.Title = newTitle;
        }

        public override string ToString()
        {
            string result = $"{this.Title} - {this.Content}: {this.Author}";

            return result.ToString();
        }
    }
}
