namespace StockMarket
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Investor
    {
        private const string COMPANY_NOT_EXIST_MESSAGE = "{0} does not exist.";
        private const string CANNOT_SELL_MESSAGE = "Cannot sell {0}.";
        private const string SUCCESSFULY_SELL_A_STOCK_MESSAGE = "{0} was sold.";

        private readonly ICollection<Stock> portfolio;

        private Investor()
        {
            this.portfolio = new HashSet<Stock>();
        }

        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
            :this()
        {
            this.FullName = fullName;
            this.EmailAddress = emailAddress;
            this.MoneyToInvest = moneyToInvest;
            this.BrokerName = brokerName;
        }

        public string FullName { get; private set; }

        public string EmailAddress { get; private set; }

        public decimal MoneyToInvest { get; private set; }

        public string BrokerName { get; private set; }

        public int Count => this.portfolio.Count;


        public void BuyStock(Stock stock)
        {
            bool canBuyAStock = stock.MarketCapitalization > 10000 && 
                                this.MoneyToInvest >= stock.PricePerShare;

            if (canBuyAStock)
            {
                this.portfolio.Add(stock);
                this.MoneyToInvest -= stock.PricePerShare;
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            var result = string.Format(COMPANY_NOT_EXIST_MESSAGE, companyName);
            var stock = this.FindStock(companyName);

            if (stock != null)
            {
                if (sellPrice < stock.PricePerShare)
                {
                    result = string.Format(CANNOT_SELL_MESSAGE, companyName);
                }
                else
                {
                    this.MoneyToInvest += sellPrice;
                    this.portfolio.Remove(stock);
                    result = string.Format(SUCCESSFULY_SELL_A_STOCK_MESSAGE, companyName);
                }
            }


            return result;
        }

        public Stock FindStock(string companyName)
        {
            return this.portfolio.SingleOrDefault(c => c.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            var company = this.portfolio
                .OrderByDescending(c => c.MarketCapitalization)
                .FirstOrDefault();

            return company;
        }

        public string InvestorInformation()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"The investor {this.FullName} with a broker {this.BrokerName} has stocks:");
            foreach (var stock in portfolio)
            {
                sb.AppendLine($"{stock}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
