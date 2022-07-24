namespace ProductShop.DTO
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class UserSoldProductsDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [JsonProperty(PropertyName = "soldProducts")]
        public ICollection<SoldProductDTO> ProductsSold { get; set; }
    }
}
