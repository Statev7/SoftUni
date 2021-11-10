namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {

        public string RevealPrivateMethods(string className)
        {
            var type = Type.GetType(className);

            var methods = type.GetMethods(BindingFlags.NonPublic | BindingFlags.Instance);

            var sb = new StringBuilder();
            sb.AppendLine($"All Private Methods of Class: {className}");
            sb.AppendLine($"Base Class: {type.BaseType.Name}");
            foreach (var method in methods)
            {
                sb.AppendLine($"{method.Name}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
