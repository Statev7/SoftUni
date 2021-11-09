namespace P01_Logger.Factories
{
    using P01_Logger.Models.Contracts;
    using P01_Logger.Models.Layuouts;

    public class LayoutFactory
    {
        public ILayout CreateLayout(string layoutType)
        {
            ILayout layout = null;

            if (layoutType == "SimpleLayout")
            {
                layout = new SimpleLayout();
            }
            else if (layoutType == "XmlLayout")
            {
                layout = new XmlLayout();
            }

            return layout;
        }
    }
}
