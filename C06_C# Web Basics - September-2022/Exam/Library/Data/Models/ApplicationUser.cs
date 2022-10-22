namespace Library.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            this.ApplicationUsersBooks = new HashSet<ApplicationUserBook>();
        }

        public ICollection<ApplicationUserBook> ApplicationUsersBooks { get; set; }
    }
}
