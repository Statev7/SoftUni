namespace Library.Models.Books
{
    public class UserBooksViewModel
    {
        public UserBooksViewModel()
        {
            this.Books = new List<BookViewModel>();
        }
        
        public IEnumerable<BookViewModel> Books { get; set; }
    }
}
