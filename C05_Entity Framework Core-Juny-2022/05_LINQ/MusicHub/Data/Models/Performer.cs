namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Performer
    {
        public Performer()
        {
            this.PerformerSongs = new HashSet<SongPerformer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(DataModelsConstants.FirstNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(DataModelsConstants.LastNameMaxLength)]
        public string LastName { get; set; }

        [Required]
        public int Age { get; set; }

        [Required]
        public decimal NetWorth  { get; set; }

        public virtual ICollection<SongPerformer> PerformerSongs { get; set; }
    }
}
