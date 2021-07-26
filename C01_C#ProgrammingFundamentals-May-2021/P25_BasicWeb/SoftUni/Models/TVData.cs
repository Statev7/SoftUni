using System.Collections.Generic;

namespace SoftUni.Models
{
    public static class TVData
    {
        static TVData()
        {
            TVs = new List<TV>();
        }

        public static List<TV> GetAll()
        {
            return TVs;
        }

        public static void Add(TV tv)
        {
            TVs.Add(tv);
        }

        public static void Delete(TV tv)
        {
            TVs.Remove(tv);
        }

        public static List<TV> TVs { get; set; }
    }
}
