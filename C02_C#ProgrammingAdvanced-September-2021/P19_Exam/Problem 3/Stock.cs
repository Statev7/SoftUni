namespace StockMarket
{
    using System.Text;

    public class Stock
    {
        public Stock(string companyName, string director, decimal pricePerShare, int totalNumberOfShares)
        {
            this.CompanyName = companyName;
            this.Director = director;
            this.PricePerShare = pricePerShare;
            this.TotalNumberOfShares = totalNumberOfShares;
        }

        public string CompanyName { get; private set; }

        public string Director { get; private set; }

        public decimal PricePerShare { get; private set; }

        public int TotalNumberOfShares { get; private set; }

        public decimal MarketCapitalization => this.PricePerShare * this.TotalNumberOfShares;

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Company: {this.CompanyName}");
            sb.AppendLine($"Director: {this.Director}");
            sb.AppendLine($"Price per share: ${this.PricePerShare}");
            sb.AppendLine($"Market capitalization: ${this.MarketCapitalization}");

            return sb.ToString().TrimEnd();
        }
    }
}
