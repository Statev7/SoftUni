namespace Footballers.DataProcessor.ExportDto
{
    using System.Xml.Serialization;

    [XmlType("Footballer")]
    public class ExportFootballerDTO
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; }

        [XmlElement(nameof(Position))]
        public string Position { get; set; }
    }
}
