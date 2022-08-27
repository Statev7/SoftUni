namespace BasicWebServer.Application.Controllers
{
    using BasicWebServer.Controllers;
    using BasicWebServer.HTTP;
    using BasicWebServer.HTTP.Cookies;
    using BasicWebServer.HTTP.Sessions;

    public class UserController : Controller
    {
        private const string LoginForm = @"<form action='/Login' method='POST'>
            Username: <input type='text' name='Username'/>
            Password: <input type='text' name='Password'/>
            <input type='submit' value ='Log In' /> 
            </form>";

        private const string Username = "user";
        private const string Password = "user123";

        public UserController(Request request) 
            : base(request)
        {
        }

        public Response Login() => this.Html(LoginForm);

        public Response LogInUser()
        {
            this.Request.Session.Clear();

            bool isUsernameMatches = this.Request.Form["Username"] == Username;
            bool isPasswordMatches = this.Request.Form["Password"] == Password;

            if (isUsernameMatches && isPasswordMatches)
            {
                if (!this.Request.Session.Contains(Session.SessionUserKey))
                {
                    this.Request.Session[Session.SessionUserKey] = "MyUserId";

                    CookieCollection cookies = new CookieCollection();
                    cookies.Add(Session.SessionCookieName, this.Request.Session.Id);

                    return this.Html("<h3>Logged successfully</h3>");
                }

                return this.Html("<h3>Logged successfully</h3>");
            }

            return this.Redirect("/Login");
        }

        public Response Logout()
        {
            this.Request.Session.Clear();

            return this.Html("<h3>Logged out successfully!</h3>");
        }

        public Response UserProfile()
        {
            bool isAuthenticated = this.Request.Session.Contains(Session.SessionUserKey);
            if (isAuthenticated)
            {
                return this.Html($"<h3>Currently logged-in user is with username '{Username}'</h3>");
            }

            return this.Redirect("/Login");
        }
    }
}
