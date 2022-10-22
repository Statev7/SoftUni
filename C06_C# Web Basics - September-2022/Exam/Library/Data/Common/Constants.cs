namespace Library.Data.Common
{
    public static class Constants
    {
        // User

        public const int UserNameMaxLength = 20;
        public const int UserNameMinLength = 5;

        public const int EmailMaxLength = 60;
        public const int EmailMinLength = 10;

        public const int PasswordMaxLength = 20;
        public const int PasswordMinLength = 5;

        // Book

        public const int BookTitleMaxLength = 50;
        public const int BookTitleMinLength = 10;

        public const int AuthorNameMaxLength = 50;
        public const int AuthorNameMinLength = 5;

        public const int DescriptionMaxLength = 5000;
        public const int DescriptionMixLength = 5;

        public const string RatingMaxValue = "10.00";
        public const string RatingMinValue = "0.00";

        // Category

        public const int CategoryNameMaxLength = 50;
        public const int CategoryNameMinLength = 5;
    }
}
