namespace Footballers.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class ImportFootballerDTO
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MaxLength(40)]
        [MinLength(2)]
        public string Name { get; set; }

        [XmlElement(nameof(ContractStartDate))]
        [Required]
        public string ContractStartDate { get; set; }

        [XmlElement(nameof(ContractEndDate))]
        [Required]
        public string ContractEndDate { get; set; }

        [XmlElement(nameof(BestSkillType))]
        public int BestSkillType { get; set; }

        [XmlElement(nameof(PositionType))]
        public int PositionType { get; set; }
    }
}
