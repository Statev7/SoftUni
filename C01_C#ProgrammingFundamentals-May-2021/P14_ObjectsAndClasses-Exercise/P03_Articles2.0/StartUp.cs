namespace P03_Articles2._0
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using P03_Articles2._0.Models;

    public class StartUp
    {
        public static void Main()
        {
            int articlesCount = int.Parse(Console.ReadLine());

            List<Article> allArticles = new List<Article>();

            for (int i = 0; i < articlesCount; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ");

                string title = arguments[0];
                string content = arguments[1];
                string author = arguments[2];

                Article article = new Article(title, content, author);

                allArticles.Add(article);
            }

            allArticles = OrderTheArticles(allArticles);
            PrintResult(allArticles);
        }

        private static List<Article> OrderTheArticles(List<Article> allArticles)
        {
            string orderByString = Console.ReadLine();

            switch (orderByString)
            {
                case "title":
                    allArticles = allArticles
                        .OrderBy(x => x.Title)
                        .ToList();
                    break;
                case "content":
                    allArticles = allArticles
                        .OrderBy(x => x.Content)
                        .ToList();
                    break;
                case "author":
                    allArticles = allArticles
                        .OrderBy(x => x.Author)
                        .ToList();
                    break;
            }
            
            return allArticles;
        }

        private static void PrintResult(List<Article> allArticles)
        {
            Console.WriteLine(string.Join(Environment.NewLine, allArticles));
        }

    }
}
