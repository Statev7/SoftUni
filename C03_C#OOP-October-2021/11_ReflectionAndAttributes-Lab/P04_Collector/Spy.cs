namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        private const string GET_METHOD_FORMAT = "{0} will return {1}";
        private const string SET_METHOD_FORMAT = "{0} will set field of {1}";

        public string Collector(string className)
        {
            var type = Type.GetType(className);
            var methods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var getMedhods = methods.Where(x => x.Name.StartsWith("get")).ToArray();
            var setMethods = methods.Where(x => x.Name.StartsWith("set")).ToArray();

            var sb = new StringBuilder();
            sb.AppendLine(this.ReturnResultAsString(getMedhods, GET_METHOD_FORMAT));
            sb.AppendLine(this.ReturnResultAsString(setMethods, SET_METHOD_FORMAT));

            return sb.ToString().TrimEnd();
        }

        private string ReturnResultAsString(MethodInfo[] methods, string format)
        {
            var sb = new StringBuilder();
            foreach (var method in methods)
            {
                string message = string.Format(format, method.Name, method.ReturnType);
                sb.AppendLine(message);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
