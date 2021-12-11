namespace Gym.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using Gym.Core.Contracts;
    using Gym.Models.Athletes;
    using Gym.Models.Athletes.Contracts;
    using Gym.Models.Equipment;
    using Gym.Models.Equipment.Contracts;
    using Gym.Models.Gyms;
    using Gym.Models.Gyms.Contracts;
    using Gym.Repositories;
    using Gym.Utilities.Messages;

    public class Controller : IController
    {
        private readonly EquipmentRepository equipment;
        private readonly List<IGym> gyms;

        public Controller()
        {
            this.equipment = new EquipmentRepository();
            this.gyms = new List<IGym>();
        }

        public string AddGym(string gymType, string gymName)
        {
            IGym gym = null;
            if (gymType == "BoxingGym")
            {
                gym = new BoxingGym(gymName);
            }
            else if (gymType == "WeightliftingGym")
            {
                gym = new WeightliftingGym(gymName);
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidGymType);
            }

            this.gyms.Add(gym);

            string result = string.Format(OutputMessages.SuccessfullyAdded, gymType);
            return result;
        }

        public string AddEquipment(string equipmentType)
        {
            IEquipment equipment = null;
            if (equipmentType == "BoxingGloves")
            {
                equipment = new BoxingGloves();
            }
            else if (equipmentType == "Kettlebell")
            {
                equipment = new Kettlebell();
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidEquipmentType);
            }

            this.equipment.Add(equipment);

            string result = string.Format(OutputMessages.SuccessfullyAdded, equipmentType);
            return result;
        }

        public string InsertEquipment(string gymName, string equipmentType)
        {
            IEquipment equipment = this.equipment.FindByType(equipmentType);

            if (equipment == null)
            {
                string message = string.Format(ExceptionMessages.InexistentEquipment, equipmentType);
                throw new InvalidOperationException(message);
            }

            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            gym.AddEquipment(equipment);
            this.equipment.Remove(equipment);

            string result = string.Format(OutputMessages.EntityAddedToGym, equipmentType, gymName);
            return result;
        }

        public string AddAthlete(string gymName, string athleteType, string athleteName, string motivation, int numberOfMedals)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);
            IAthlete athlete = null;

            if (athleteType == "Boxer")
            {
                if (gym.GetType().Name == "BoxingGym")
                {
                    athlete = new Boxer(athleteName, motivation, numberOfMedals);
                }
                else
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else if (athleteType == "Weightlifter")
            {
                if (gym.GetType().Name == "WeightliftingGym")
                {
                    athlete = new Weightlifter(athleteName, motivation, numberOfMedals);
                }
                else
                {
                    return OutputMessages.InappropriateGym;
                }
            }
            else
            {
                throw new InvalidOperationException(ExceptionMessages.InvalidAthleteType);
            }

            gym.AddAthlete(athlete);

            string result = string.Format(OutputMessages.EntityAddedToGym, athleteType, gymName);
            return result;
        }

        public string TrainAthletes(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            foreach (var athlete in gym.Athletes)
            {
                athlete.Exercise();
            }

            int count = gym.Athletes.Count;

            string result = string.Format(OutputMessages.AthleteExercise, count);
            return result;
        }

        public string EquipmentWeight(string gymName)
        {
            IGym gym = this.gyms.FirstOrDefault(g => g.Name == gymName);

            double weight = gym.EquipmentWeight;
            string weightAsString = $"{weight:F2}";

            string result = string.Format(OutputMessages.EquipmentTotalWeight, gymName, weightAsString);
            return result;
        }

        public string Report()
        {
            var sb = new StringBuilder();
            foreach (var gym in this.gyms)
            {
                sb.AppendLine(gym.GymInfo());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
