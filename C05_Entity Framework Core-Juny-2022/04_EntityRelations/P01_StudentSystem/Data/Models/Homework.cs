namespace P01_StudentSystem.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using P01_StudentSystem.Enums;

    public class Homework
    {
        public int HomeworkId { get; set; }

        [Required]
        public string Content { get; set; }

        [Required]
        public ContentType ContentType { get; set; }

        [Required]
        public DateTime SubmissionTime { get; set; }

        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
