namespace VehiclesExtension.Core
{
    using System;
    using System.Linq;

    using VehiclesExtension.Common;
    using VehiclesExtension.Core.Contracts;
    using VehiclesExtension.IO.Contracts;
    using VehiclesExtension.Models;

    public class Engine : IEngine
    {
        private static Car car;
        private static Truck truck;
        private static Bus bus;

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
            this.CreateBus();
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
            var tankCapacity = double.Parse(carArgments[2]);

            car = new Car(quantity, consumption, tankCapacity);
        }

        private void CreateTruck()
        {
            var truckArgments = reader.Read()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Skip(1)
                                        .ToArray(); ;

            var quantity = double.Parse(truckArgments[0]);
            var consumption = double.Parse(truckArgments[1]);
            var tankCapacity = double.Parse(truckArgments[2]);

            truck = new Truck(quantity, consumption, tankCapacity);
        }

        private void CreateBus()
        {
            var busArgments = reader.Read()
                                        .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                                        .Skip(1)
                                        .ToArray(); ;

            var quantity = double.Parse(busArgments[0]);
            var consumption = double.Parse(busArgments[1]);
            var tankCapacity = double.Parse(busArgments[2]);

            bus = new Bus(quantity, consumption, tankCapacity);
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
                var thirtArg = double.Parse(cmdArg[2]);

                try
                {
                    switch (command)
                    {
                        case "Refuel": this.Refual(vehicleType, thirtArg); break;
                        case "Drive": this.Drive(vehicleType, thirtArg); break;
                        case "DriveEmpty": this.DriveEmpty(thirtArg); break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }
        }

        private void Refual(string vehicleType, double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException(GlobalMessages.FUEL_MUST_BE_POSITIVE_ERROR_MESSAGE);
            }

            switch (vehicleType)
            {
                case "Car": car.Refuel(liters); break;
                case "Truck": truck.Refuel(liters); break;
                case "Bus": bus.Refuel(liters); break;
            }
        }

        private void Drive(string vehicleType, double distance)
        {
            string msg = string.Empty;

            switch (vehicleType)
            {
                case "Car": msg = car.Drive(distance); break;
                case "Truck": msg = truck.Drive(distance); break;
                case "Bus": msg = bus.Drive(distance); break;
            }

            writer.WriteLine(msg);
        }

        private void DriveEmpty(double distance)
        {
            Console.WriteLine(bus.DriveEmpty(distance));
        }

        private void PrintOutput()
        {
            writer.WriteLine($"Car: {car.FuelQuantity:F2}");
            writer.WriteLine($"Truck: {truck.FuelQuantity:F2}");
            writer.WriteLine($"Bus: {bus.FuelQuantity:F2}");
        }
    }
}
