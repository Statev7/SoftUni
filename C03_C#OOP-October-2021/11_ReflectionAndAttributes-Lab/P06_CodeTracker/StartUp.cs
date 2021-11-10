namespace AuthorProblem
{
    using System;

    [Author("Victor")]
    public class StartUp
    {
        [Author("George")]
        [Author("Pecata")]
        public static void Main()
        {
            var tracker = new Tracker();
            tracker.PrintMethodsByAuthor();

        }
    }
}
