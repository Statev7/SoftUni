namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;

    public class ImportTeamDTO
    {
        [Required]
        [RegularExpression(@"^[A-Za-z0-9\s.-]+$")]
        [MaxLength(40)]
        [MinLength(3)]
        public string Name { get; set; }

        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Nationality { get; set; }

        [Range(1, int.MaxValue)]
        public int Trophies { get; set; }

        public int[] Footballers { get; set; }
    }
}
