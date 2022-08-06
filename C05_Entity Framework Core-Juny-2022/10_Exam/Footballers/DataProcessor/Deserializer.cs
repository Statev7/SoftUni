namespace Footballers.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using AutoMapper;

    using Data;

    using Footballers.Data.Models;
    using Footballers.Data.Models.Enums;
    using Footballers.DataProcessor.ImportDto;

    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedCoach
            = "Successfully imported coach - {0} with {1} footballers.";

        private const string SuccessfullyImportedTeam
            = "Successfully imported team - {0} with {1} footballers.";

        public static string ImportCoaches(FootballersContext context, string xmlString)
        {
            var sb = new StringBuilder();

            var coachWithFootballersDTOs = XmlDeserializer<ImportCoachWithFootballersDTO[]>("Coaches", xmlString);
            ICollection<Coach> coaches = new List<Coach>();

            foreach (var coachDto in coachWithFootballersDTOs)
            {
                if (!IsValid(coachDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Coach coach = new Coach
                {
                    Name = coachDto.Name,
                    Nationality = coachDto.Nationality,
                };

                ICollection<Footballer> footballers = new List<Footballer>();

                foreach (var footballerDto in coachDto.Footballers)
                {
                    if (!IsValid(footballerDto))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime contractStartDate;
                    bool isStartDateValid = DateTime.TryParseExact(footballerDto.ContractStartDate,"dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out contractStartDate);

                    DateTime contractEndDate;
                    bool isEndDateValid = DateTime.TryParseExact(footballerDto.ContractEndDate, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out contractEndDate);

                    if (!isStartDateValid || !isEndDateValid)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (contractStartDate > contractEndDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    Footballer footballer = new Footballer()
                    {
                        Name = footballerDto.Name,
                        ContractStartDate = contractStartDate,
                        ContractEndDate = contractEndDate,
                        BestSkillType = (BestSkillType)footballerDto.BestSkillType,
                        PositionType = (PositionType)footballerDto.PositionType
                    };

                    footballers.Add(footballer);
                }

                coach.Footballers = footballers;
                coaches.Add(coach);

                string message = string.Format(SuccessfullyImportedCoach, coach.Name, coach.Footballers.Count);
                sb.AppendLine(message);
            }

            context.Coaches.AddRange(coaches);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }
        public static string ImportTeams(FootballersContext context, string jsonString)
        {
            var sb = new StringBuilder();

            ImportTeamDTO[] importTeamDTOs = JsonConvert.DeserializeObject<ImportTeamDTO[]>(jsonString);
            ICollection<Team> teams = new List<Team>();

            foreach (var teamDto in importTeamDTOs)
            {
                if (!IsValid(teamDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                Team team = Mapper.Map<Team>(teamDto);
                List<int> validFootballerIds = context.Footballers
                    .Select(f => f.Id)
                    .ToList();

                foreach (var footballerId in teamDto.Footballers.Distinct().ToList())
                {
                    if (!validFootballerIds.Any(x => x == footballerId))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    TeamFootballer teamFootballer = new TeamFootballer()
                    {
                        Team = team,
                        FootballerId = footballerId,
                    };

                    team.TeamsFootballers.Add(teamFootballer);
                }

                teams.Add(team);
                string message = string.Format(SuccessfullyImportedTeam, team.Name, team.TeamsFootballers.Count);
                sb.AppendLine(message);
            }

            context.Teams.AddRange(teams);
            context.SaveChanges();

            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new System.ComponentModel.DataAnnotations.ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }

        private static T XmlDeserializer<T>(string rootTag, string inputXml)
        {
            XmlRootAttribute root = new XmlRootAttribute(rootTag);
            XmlSerializer serializer = new XmlSerializer(typeof(T), root);

            T dtos;

            using (StringReader reader = new StringReader(inputXml))
            {
                dtos = (T)serializer.Deserialize(reader);
            }

            return dtos;
        }
    }
}
