namespace Footballers.DataProcessor
{
    using System;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    using Data;

    using Footballers.DataProcessor.ExportDto;

    using Microsoft.EntityFrameworkCore;

    using Newtonsoft.Json;

    using Formatting = Newtonsoft.Json.Formatting;

    public class Serializer
    {
        public static string ExportCoachesWithTheirFootballers(FootballersContext context)
        {
            ExportCoachWithFootballersDTO[] coaches = context
                .Coaches
                .Include(c => c.Footballers)
                .Where(c => c.Footballers.Any())
                .ToArray()
                .Select(c => new ExportCoachWithFootballersDTO
                {
                    FootballersCount = c.Footballers.Count,
                    CoachName = c.Name,
                    Footballers = c.Footballers.Select(f => new ExportFootballerDTO
                    {
                        Name = f.Name,
                        Position = f.PositionType.ToString()
                    })
                    .OrderBy(f => f.Name)
                    .ToArray()

                })
                .OrderByDescending(x => x.FootballersCount)
                .ThenBy(x => x.CoachName)
                .ToArray();

            string result = XmlSerializer(coaches, "Coaches");
            return result;
        }

        public static string ExportTeamsWithMostFootballers(FootballersContext context, DateTime date)
        {
            var teams = context.Teams
                .Include(t => t.TeamsFootballers)
                .ThenInclude(t => t.Footballer)
                .Where(t => t.TeamsFootballers.Any(tf => tf.Footballer.ContractStartDate >= date))
                .ToList()
                .Select(t => new
                {
                    t.Name,
                    Footballers = t.TeamsFootballers
                            .Where(tf => tf.Footballer.ContractStartDate >= date)
                            .OrderByDescending(tf => tf.Footballer.ContractEndDate)
                            .ThenBy(tf => tf.Footballer.Name)
                            .Select(tf => new
                            {
                                FootballerName = tf.Footballer.Name,
                                ContractStartDate = tf.Footballer.ContractStartDate.ToString("d", CultureInfo.InvariantCulture),
                                ContractEndDate = tf.Footballer.ContractEndDate.ToString("d", CultureInfo.InvariantCulture),
                                BestSkillType = tf.Footballer.BestSkillType.ToString(),
                                PositionType = tf.Footballer.PositionType.ToString()
                            })
                            .ToList()
                })
                .OrderByDescending(x => x.Footballers.Count)
                .ThenBy(x => x.Name)
                .Take(5)
                .ToList();

            string result = JsonConvert.SerializeObject(teams, Formatting.Indented);
            return result;
        }

        private static string XmlSerializer<T>(T dto, string rootTag)
        {
            var sb = new StringBuilder();

            var root = new XmlRootAttribute(rootTag);
            var namespaces = new XmlSerializerNamespaces();
            namespaces.Add(String.Empty, String.Empty);

            var serializer = new XmlSerializer(typeof(T), root);
            using (StringWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, dto, namespaces);
            }

            return sb.ToString().TrimEnd();
        }
    }
}
