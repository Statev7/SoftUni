namespace Library.Models.Books
{
    using System.ComponentModel.DataAnnotations;

    using Library.Models.Categories;

    using static Library.Data.Common.Constants;

    public class CreateBookInputModel
    {
        public CreateBookInputModel()
        {
            this.Categories = new List<CategoryIdNameViewModel>();
        }

        [Required]
        [MaxLength(BookTitleMaxLength)]
        [MinLength(BookTitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [MaxLength(AuthorNameMaxLength)]
        [MinLength(AuthorNameMinLength)]
        public string Author { get; set; } = null!;

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [MinLength(DescriptionMixLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Url]
        public string ImageUrl { get; set; } = null!;

        [Required]
        [Range(typeof(decimal), RatingMinValue, RatingMaxValue)]
        public decimal Rating { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryIdNameViewModel> Categories { get; set; }
    }
}
