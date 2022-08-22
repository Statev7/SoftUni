namespace P01_Chronometer.Factories
{
    using System;
    using System.Linq;
    using System.Reflection;

    using P01_Chronometer.Commands.Contracts;
    using P01_Chronometer.Factories.Contracts;

    public class CommandFactory : IFactory<ICommand>
    {
        private const string CommandSuffix = "command";

        public ICommand Create(params string[] args)
        {
            string commandType = args[0].ToLower() + CommandSuffix;

            Type type = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandType);

            if (type is null)
            {
                throw new ArgumentException("Invalid type!");
            }

            ICommand command = Activator.CreateInstance(type) as ICommand;
            return command;
        }
    }
}
