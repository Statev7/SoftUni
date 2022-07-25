namespace ProductShop.Dtos.Export
{
    using System.Xml.Serialization;

    public class ExportUsers
    {
        [XmlElement("count")]
        public int Count { get; set; }

        [XmlArray("users")]
        public ExportUsersWithProductsDTO[] Users { get; set; }
    }
}
