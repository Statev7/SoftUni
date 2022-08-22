namespace BasicWebServer.Common
{
    using System;

    public static class Guard
    {
        public static void AgaintsNull(object value, string name = null)
        {
            if (value == null)
            {
                name ??= "Value";

                throw new ArgumentException($"{name} cannot be null!");
            }
        }
    }
}
