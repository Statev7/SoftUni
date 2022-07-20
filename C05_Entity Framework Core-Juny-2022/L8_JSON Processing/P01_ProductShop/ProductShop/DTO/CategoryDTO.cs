namespace ProductShop.DTO
{
    using Newtonsoft.Json;

    public class CategoryDTO
    {
        [JsonProperty(PropertyName = "category")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "productsCount")]
        public int CategoryProductsCount { get; set; }

        public string AveragePrice { get; set; }

        public string TotalRevenue { get; set; }
    }
}
