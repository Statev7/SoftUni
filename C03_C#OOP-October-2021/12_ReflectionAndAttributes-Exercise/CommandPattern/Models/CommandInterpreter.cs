namespace CommandPattern.Models
{
    using System;
    using System.Linq;
    using System.Reflection;

    using CommandPattern.Core.Contracts;

    public class CommandInterpreter : ICommandInterpreter
    {
        private const string COMMAND_SUFFIX = "Command";

        public string Read(string args)
        {
            var splitedArgs = args
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            var commandType = splitedArgs[0] + COMMAND_SUFFIX;
            var arguments = splitedArgs.Skip(1).ToArray();

            var assembly = Assembly.GetCallingAssembly();
            var type = assembly.GetTypes()
                .SingleOrDefault(x => x.Name.ToLower() == commandType.ToLower());

            if (type == null)
            {
                throw new ArgumentException("Invalid command!");
            }

            var instance = (ICommand)Activator.CreateInstance(type);
            var result = instance.Execute(arguments);

            return result;
        }
    }
}
