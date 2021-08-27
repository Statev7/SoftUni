namespace P05_DataModifier
{
    using System;

    public class DateModifier
    {
        public DateModifier()
        {
            
        }

        public int DifferenceBetweenTwoDates(string startDate, string endDate)
        {
            var result = DateTime.Parse(endDate) - DateTime.Parse(startDate);

            return int.Parse(result.Days.ToString());
        }

    }
}
