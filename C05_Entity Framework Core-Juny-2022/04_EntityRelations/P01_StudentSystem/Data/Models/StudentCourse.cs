namespace P01_StudentSystem.Data.Models
{
    public class StudentCourse
    {
        public int StudentId { get; set; }

        public virtual Student Student { get; set; }

        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}
