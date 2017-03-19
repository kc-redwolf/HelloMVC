using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;


namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        public static Dictionary<string, string> Languages = new Dictionary<string, string>()
        {
            {"English", "Hello"},
            {"French", "Bonjour"},
            {"Spanish", "Hola"},
            {"German", "Guten Tag"},
            {"Italian", "Ciao"}
        };
        
        [HttpPost]
        public IActionResult Add(string name, string language)
        {
            string message = "{0}, {1}";
            string hello = "Hello";

            if (Languages.ContainsKey(language))
            {
                hello = Languages[language];
            }

            string page = pageBase(string.Format(message, hello, name));

            return Content(page, "text/html");
        }
        
          
        [HttpGet]
        public IActionResult Index()
        {
            string pageContent = @"
                <form method='POST' action='/Hello/Add'>
                    <label>
                        Name:
                        <input type='text' name='name' />
                    </label>
                    <label>
                        Language:
                        <select name='language'>
                            <option value='English'>English<option>
                            <option value='French'>French</option>
                            <option value='Spanish'>Spanish</option>
                            <option value='German'>German</option>
                            <option value='Italian'>Italian</option>
                        </select>
                    </label>
                    <button type='submit'>Greet Me!</button>
                </form>";

            string message = pageBase(pageContent);

            return Content(message, "text/html");
        }

        public string pageBase(string message)
        {
            return string.Format(@"
            <!DOCTYPE html>
            <html>
            <head>
                <meta charset='utf-8' />
                <meta name='viewport' content='width=device-width, initial-scale=1.0' />
                <title>WebApplication</title>
                <link rel='stylesheet' href='https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/css/bootstrap.min.css' />
                <link rel='stylesheet' href='/css/site.min.css' /> <!-- provided by dotnet -->
            </head>
            <body>
                <div class='navbar navbar-inverse navbar-fixed-top'>
                    <div class='container'>
                        <div class='navbar-header'>
                            <button type='button' class='navbar-toggle' data-toggle='collapse' data-target='.navbar-collapse'>
                                <span class='sr-only'>Toggle navigation</span>
                                <span class='icon-bar'></span>
                                <span class='icon-bar'></span>
                                <span class='icon-bar'></span>
                            </button>
                            <a href='/' class='navbar-brand'>Example App</a>
                        </div>
                        <div class='navbar-collapse collapse'>
                            <ul class='nav navbar-nav'>
                                <li><a href='/'>Home</a></li>
                                <li><a href='/Home/About'>About</a></li>
                                <li><a href='/Home/Contact'>Contact</a></li>
                            </ul>
                        </div>
                    </div>
                </div>
                <div class='container body-content'>
                    {0} <!-- this is where the body is at -->
                    <hr />
                    <footer>
                        <p>&copy; 2016 - WebApplication</p>
                    </footer>
                </div>
                <script src='https://ajax.aspnetcdn.com/ajax/jquery/jquery-2.2.3.min.js'>
                </script>
                <script src='https://ajax.aspnetcdn.com/ajax/bootstrap/3.3.6/bootstrap.min.js'>
                </script>
            </body>
            </html>", message);
        }
    }

}
