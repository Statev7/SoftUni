namespace Library.Controllers
{
    using System.Security.Claims;

    using Library.Models.Books;
    using Library.Services.Contracts;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BooksController : Controller
    {
        private readonly IBookService bookService;
        private readonly ICategoryService categoryService;
        private readonly IUserBookService userService;

        public BooksController
            (IBookService bookService, 
            ICategoryService categoryService,
            IUserBookService userService)
        {
            this.bookService = bookService;
            this.categoryService = categoryService;
            this.userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await this.bookService.GetAllAsync();

            return this.View(books);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new CreateBookInputModel()
            {
                Categories = await this.categoryService.GetAllAsync(),
            };

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(CreateBookInputModel book)
        {
            if (!this.ModelState.IsValid)
            {
                book.Categories = await this.categoryService.GetAllAsync();
                return this.View(book);
            }

            var isCategoryExist = await this.categoryService.IsExistAsync(book.CategoryId);
            if (!isCategoryExist)
            {
                //TODO: Dispaly error!
                this.ModelState.AddModelError("", "Invalid category!");

                book.Categories = await this.categoryService.GetAllAsync();
                return this.View(book);
            }

            await this.bookService.CreateAsync(book);
            return this.RedirectToAction(nameof(this.All));
        }

        [HttpGet]
        public async Task<IActionResult> Mine()
        {
            var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
            var books = await this.bookService.GetAllByUserIdAsync(userId);

            return this.View(books);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCollection(int bookId)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await this.userService.AddBookAsync(bookId, userId);
            }
            catch (Exception)
            {
                
            }

            return this.RedirectToAction(nameof(this.All));
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCollection(int bookId)
        {
            try
            {
                var userId = this.User.FindFirstValue(ClaimTypes.NameIdentifier);
                await this.userService.RemoveBookAsync(bookId, userId);
            }
            catch (Exception)
            {

            }

            return this.RedirectToAction(nameof(this.Mine));
        }
    }
}
