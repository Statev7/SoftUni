namespace Vehicles.Core
{
    using System;
    using System.Linq;

    using Vehicles.Core.Contracts;
    using Vehicles.IO.Contracts;
    using Vehicles.Models;

    public class Engine : IEngine
    {
        private Vehicle car;
        private Vehicle truck;

        private IReader reader;
        private IWriter writer;

        public Engine(IReader reader, IWriter writer)
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.CreateCar();
            this.CreateTruck();
            this.ExecuteCommands();
            this.PrintOutput();
        }

        private void CreateCar()
        {
            var carArgments = reader.Read()
                            .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                            .Skip(1)
                            .ToArray();

            var quantity = double.Parse(carArgments[0]);
            var consumption = double.Parse(carArgments[1]);

            this.car = new Car(quantity, consumption);
        }

        private void CreateTruck()
        {
            var truckArgments = reader.Read()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Skip(1)
                                        .ToArray(); ;

            var quantity = double.Parse(truckArgments[0]);
            var consumption = double.Parse(truckArgments[1]);

            this.truck = new Truck(quantity, consumption);
        }

        private void ExecuteCommands()
        {
            int operationCount = int.Parse(reader.Read());

            for (int i = 0; i < operationCount; i++)
            {
                var cmdArg = reader.Read()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                var command = cmdArg[0];
                var vehicleType = cmdArg[1];
                var arg = double.Parse(cmdArg[2]);

                switch (command)
                {
                    case "Refuel": this.Refual(vehicleType, arg); break;
                    case "Drive": this.Drive(vehicleType, arg); break;
                }
            }
        }

        private void Refual(string vehicleType, double liters)
        {
            switch (vehicleType)
            {
                case "Car": car.Refuel(liters); break;
                case "Truck": truck.Refuel(liters); break;
            }
        }

        private void Drive(string vehicleType, double distance)
        {
            string msg = string.Empty;

            switch (vehicleType)
            {
                case "Car": msg = car.Drive(distance); break;
                case "Truck": msg = truck.Drive(distance); break;
            }
            writer.WriteLine(msg);
        }

        private void PrintOutput()
        {
            writer.WriteLine(car.ToString());
            writer.WriteLine(truck.ToString());
        }
    }
}
