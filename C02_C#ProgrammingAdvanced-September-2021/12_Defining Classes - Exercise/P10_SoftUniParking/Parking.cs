namespace SoftUniParking
{
    using System.Collections.Generic;
    using System.Linq;

    public class Parking
    {
        private const string PARKING_IS_FULL_ERROR_MESSAGE = "Parking is full";
        private const string CAR_ALREDY_EXIST_ERROR_MESSAGE = "Car with that registration number, already exists!";
        private const string SUCCESSFULLY_REGISTER_A_CAR_MESSAGE = "Successfully added new car {0} {1}";
        private const string CAR_NOT_EXIST_ERROR_MESSAGE = "Car with that registration number, doesn't exist!";
        private const string SUCCESSFULY_REMOVE_A_CAR_MESSAGE = "Successfully removed {0}";

        private List<Car> cars;
        private int capacity;

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.Capacity = capacity;
        }

        public int Capacity { private get; set; }

        public int Count => this.cars.Count;

        public string AddCar(Car car)
        {
            string result = string.Empty;
            bool isCarAlredyExist = cars.Any(x => x.RegistrationNumber == car.RegistrationNumber);
            bool isCapacityIsFull = this.cars.Count >= this.Capacity;

            if (isCarAlredyExist)
            {
                result = CAR_ALREDY_EXIST_ERROR_MESSAGE;
            }
            else if (isCapacityIsFull)
            {
                result = PARKING_IS_FULL_ERROR_MESSAGE;
            }
            else
            {
                this.cars.Add(car);
                result = string.Format(SUCCESSFULLY_REGISTER_A_CAR_MESSAGE, car.Make, car.RegistrationNumber);
            }

            return result;
        }

        public string RemoveCar(string registrationNumber)
        {
            string result = CAR_NOT_EXIST_ERROR_MESSAGE;

            Car car = this.cars
                .Where(x => x.RegistrationNumber == registrationNumber)
                .SingleOrDefault();

            if (car != null)
            {
                this.cars.Remove(car);
                result = string.Format(SUCCESSFULY_REMOVE_A_CAR_MESSAGE, registrationNumber);
            }

            return result;
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = this.cars
                .Where(x => x.RegistrationNumber == registrationNumber)
                .First();

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            this.cars = cars.Where(c => !registrationNumbers.Contains(c.RegistrationNumber)).ToList();
        }
    }
}
