namespace WildFarm.Common.Exeptions
{
    using System;

    public class EatExeption : Exception
    {
        public EatExeption(string message) 
            : base(message)
        {
        }
    }
}
