namespace BookShop
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;

    using BookShop.Data;
    using BookShop.Initializer;
    using BookShop.Models.Enums;

    public class StartUp
    {
        public static void Main()
        {
            var dbContext = new BookShopContext();
            //DbInitializer.ResetDatabase(dbContext);

            Console.WriteLine(RemoveBooks(dbContext));
        }

        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            AgeRestriction ageRestriction;
            Enum.TryParse(command, true, out ageRestriction);

            var bookTitles = context.Books
                .Where(b => b.AgeRestriction == ageRestriction)
                .Select(b => b.Title)
                .OrderBy(b => b);

            string result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        public static string GetGoldenBooks(BookShopContext context)
        {
            var bookTitles = context.Books
                .Where(b => b.EditionType == EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            string result = string.Join(Environment.NewLine, bookTitles);

            return result;
        }

        public static string GetBooksByPrice(BookShopContext context)
        {
            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    b.Price
                })
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            var bookTitles = context.Books
                .Where(b => b.ReleaseDate.Value.Year != year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToList();

            var sb = new StringBuilder();
            foreach (var title in bookTitles)
            {
                sb.AppendLine(title);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            var categories = input
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(x => x.ToLower())
                .ToArray();

            var books = context.Books
                .Select(b => new
                {
                    b.Title,
                    CategorieNames = b.BookCategories
                    .Select(bg => bg.Category.Name.ToLower())
                })
                .OrderBy(b => b.Title)
                .ToList()
                .Where(b =>
                {
                    return categories.Intersect(b.CategorieNames).ToList().Count() > 0;
                });

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetBooksReleasedBefore(BookShopContext context, string dateAsString)
        {
            DateTime date = DateTime
                .ParseExact(dateAsString, "dd-MM-yyyy", CultureInfo.InvariantCulture);

            var books = context.Books
                .Where(b => b.ReleaseDate < date)
                .OrderByDescending(b => b.ReleaseDate)
                .Select(b => new
                {
                    b.Title,
                    b.EditionType,
                    b.Price
                })
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            var authors = context.Authors
                .Where(a => a.FirstName.EndsWith(input))
                .Select(a => a.FirstName + " " + a.LastName)
                .OrderBy(a => a)
                .ToList();

            string result = string.Join(Environment.NewLine, authors);
            return result;
        }

        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            var bookTitles = context.Books
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToList();

            string result = string.Join(Environment.NewLine, bookTitles);
            return result;
        }

        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    FullName = b.Author.FirstName + " " + b.Author.LastName
                })
                .OrderBy(b => b.BookId)
                .ToList();

            var sb = new StringBuilder();
            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.FullName})");
            }

            return sb.ToString().TrimEnd();
        }

        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var bookCount = context.Books
                .Where(b => b.Title.Length > lengthCheck)
                .Count();

            return bookCount;
        }

        public static string CountCopiesByAuthor(BookShopContext context)
        {
            var authors = context.Authors
                .Select(a => new
                {
                    FullName = a.FirstName + " " + a.LastName,
                    Copies = a.Books
                            .Select(b => b.Copies)
                            .Sum()
                })
                .OrderByDescending(x => x.Copies)
                .ToList();

            var sb = new StringBuilder();
            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            var categories = context.Categories
                 .Select(c => new
                 {
                     c.Name,
                     Profit = c.CategoryBooks
                        .Select(cb => cb.Book)
                        .Sum(b => b.Copies * b.Price)
                 })
                 .OrderByDescending(c => c.Profit)
                 .ToList();


            var sb = new StringBuilder();

            foreach (var category in categories)
            {
                sb.AppendLine($"{category.Name} ${category.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetMostRecentBooks(BookShopContext context)
        {
            var categories = context.Categories
                .Select(c => new
                {
                    c.Name,
                    RecentBooks = c.CategoryBooks.Select(cb => new
                    {
                        cb.Book.Title,
                        cb.Book.ReleaseDate
                    })
                    .OrderByDescending(x => x.ReleaseDate)
                    .Take(3)
                })
                .OrderBy(x => x.Name)
                .ToList();

            var sb = new StringBuilder();
            foreach (var category in categories)
            {
                sb.AppendLine($"--{category.Name}");
                foreach (var book in category.RecentBooks)
                {
                    sb.AppendLine($"{book.Title} ({book.ReleaseDate.Value.Year})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        public static void IncreasePrices(BookShopContext context)
        {
            var booksToUpdate = context.Books
                .Where(b => b.ReleaseDate.Value.Year < 2010)
                .ToList();

            foreach (var book in booksToUpdate)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        public static int RemoveBooks(BookShopContext context)
        {
            var booksToRemove = context.Books
                .Where(b => b.Copies < 4200)
                .ToList();

            context.RemoveRange(booksToRemove);
            context.SaveChanges();

            return booksToRemove.Count();
        }
    }
}
