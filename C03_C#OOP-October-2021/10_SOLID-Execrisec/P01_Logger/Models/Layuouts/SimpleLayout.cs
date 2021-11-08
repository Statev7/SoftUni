namespace P01_Logger.Models.Layuouts
{
    using P01_Logger.Models.Contracts;

    public class SimpleLayout : ILayout
    {
        public string Format => "{0} - {1} - {2}";
    }
}
