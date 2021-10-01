namespace VehiclesExtension.Common
{
    using System;

    public static class VenhicleValidator
    {
        public static void CanFitFuel(double liters, double tankCapacity)
        {
            if (liters > tankCapacity)
            {
                throw new ArgumentException(string.Format(GlobalMessages.CANNOT_FIT_FUEL,liters));
            }
        }
    }
}
