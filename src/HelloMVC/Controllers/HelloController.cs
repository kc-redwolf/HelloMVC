using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace HelloMVC.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            string html = "<form method='post' action='/Hello/Display'>" +
                "<input type='text' name='name' />" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";

            return Content(string.Format("<h1>Hello {0}!</h1>", name), "text/html");
        }
        public IActionResult Display(string name = "World")
        {
            return Content(string.Format("<h1>Hello {0}!</h1>", name), "text/html");
        }
        
        public IActionResult Goodbye()
        {
            return Content("Goodbye");
        }
    }

}
