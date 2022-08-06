namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ImportCoachWithFootballersDTO
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [XmlElement(nameof(Nationality))]
        [Required]
        public string Nationality { get; set; }

        [XmlArray(nameof(Footballers))]
        public ImportFootballerDTO[] Footballers { get; set; }
    }
}
