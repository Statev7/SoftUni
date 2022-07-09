namespace MusicHub.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using MusicHub.Common;

    public class Writer
    {
        public Writer()
        {
            this.Songs = new HashSet<Song>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(DataModelsConstants.WriterNameMaxLength)]
        public string Name { get; set; }

        public string Pseudonym  { get; set; }

        public virtual ICollection<Song> Songs { get; set; }
    }
}
