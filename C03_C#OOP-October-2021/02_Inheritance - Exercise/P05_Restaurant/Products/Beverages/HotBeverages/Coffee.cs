namespace Restaurant.Products.Beverages.HotBeverages
{
    public class Coffee : HotBeverage
    {
        private const double COFFEE_MILLILITERS = 50;
        private const decimal COFFE_PRICE = 3.5m;

        public Coffee(string name, double caffeine)
            :base(name, COFFE_PRICE, COFFEE_MILLILITERS)
        {
            this.Caffeine = caffeine;
        }

        public double Caffeine  { get; set; }
    }
}
