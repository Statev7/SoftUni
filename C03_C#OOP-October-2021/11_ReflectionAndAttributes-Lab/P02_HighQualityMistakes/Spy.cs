namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string AnalyzeAccessModifiers(string className)
        {
            var type = Type.GetType(className);

            var filds = type.GetFields(BindingFlags.Static | BindingFlags.Instance | BindingFlags.Public);
            var publicMethods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance);
            var privateMethods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var sb = new StringBuilder();
            foreach (var field in filds)
            {
                sb.AppendLine($"{field.Name} must be private!");
            }

            foreach (var method in publicMethods.Where(x => x.Name.StartsWith("get")))
            {
                sb.AppendLine($"{method.Name} must be public!");
            }

            foreach (var method in privateMethods.Where(x => x.Name.StartsWith("set"))) 
            {
                sb.AppendLine($"{method.Name} must be public!");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
