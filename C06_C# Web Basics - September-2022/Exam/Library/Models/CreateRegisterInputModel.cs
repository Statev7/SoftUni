namespace Library.Models
{
    using System.ComponentModel.DataAnnotations;

    using static Library.Data.Common.Constants;

    public class CreateRegisterInputModel
    {
        [Required]
        [Display(Name = "Username")]
        [MaxLength(UserNameMaxLength)]
        [MinLength(UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [EmailAddress]
        [MaxLength(EmailMaxLength)]
        [MinLength(EmailMinLength)]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [MaxLength(PasswordMaxLength)]
        [MinLength(PasswordMinLength)]
        public string Password { get; set; } = null!;

        [Display(Name = "Confirm password")]
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; } = null!;
    }
}
