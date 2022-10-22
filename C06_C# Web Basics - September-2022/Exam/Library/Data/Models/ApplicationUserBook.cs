namespace Library.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class ApplicationUserBook
    {
        [Required]
        public string ApplicationUserId { get; set; } = null!;

        public ApplicationUser ApplicationUser { get; set; } = null!;

        public int BookId { get; set; }

        public Book Book { get; set; } = null!;
    }
}
