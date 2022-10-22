namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Library.Data.Common.Constants;

    public class Category
    {
        public Category()
        {
            this.Books = new HashSet<Book>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; }
    }
}
