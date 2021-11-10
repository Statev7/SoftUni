namespace Stealer
{
    using System;
    using System.Linq;
    using System.Reflection;
    using System.Text;

    public class Spy
    {
        public string StealFieldInfo(string classToInvestigate, params string[] filds)
        {
            var classType = Type.GetType(classToInvestigate);
            var classFilds = classType.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            var classInstance = Activator.CreateInstance(classType, new object[] { });

            var sb = new StringBuilder();
            sb.AppendLine($"Class under investigation: {classToInvestigate}");
            foreach (var fild in classFilds.Where(x => filds.Contains(x.Name)))
            {
                sb.AppendLine($"{fild.Name} = {fild.GetValue(classInstance)}");
            }
            

            return sb.ToString().TrimEnd();
        }
    }
}
