namespace Footballers.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Coach")]
    public class ExportCoachWithFootballersDTO
    {
        [XmlAttribute(nameof(FootballersCount))]
        public int FootballersCount { get; set; }

        [XmlElement(nameof(CoachName))]
        public string CoachName { get; set; }

        [XmlArray(nameof(Footballers))]
        public ExportFootballerDTO[] Footballers { get; set; }
    }
}
