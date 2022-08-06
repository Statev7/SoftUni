namespace Footballers.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using Footballers.Data.Models.Enums;

    public class Footballer
    {
        public Footballer()
        {
            this.TeamsFootballers = new HashSet<TeamFootballer>();
        }

        public int Id { get; set; }

        [Required]
        [MaxLength(40)]
        public string Name { get; set; }

        public DateTime ContractStartDate  { get; set; }

        public DateTime ContractEndDate  { get; set; }

        public PositionType PositionType  { get; set; }

        public BestSkillType BestSkillType { get; set; }

        public int CoachId  { get; set; }

        public Coach Coach { get; set; }

        public ICollection<TeamFootballer> TeamsFootballers  { get; set; }
    }
}
