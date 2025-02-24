using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Required for session management

namespace Product.Controllers
{
    public class UserController : Controller
    {
        public IActionResult SetSession()
        {
            // Store session values
            HttpContext.Session.SetString("UserName", "Paul Jesu");
            HttpContext.Session.SetInt32("UserID", 101);

            HttpContext.Session.SetString("Name", "Paul");
            //string url = Url.Action("Index", "User");
            //return Redirect(url);

            return RedirectToAction("Index");
        }

        //[HttpGet]
        //public IActionResult Index()
        //{
        //    // Retrieve session values
        //    string? userName = HttpContext.Session.GetString("UserName");
        //    int? userId = HttpContext.Session.GetInt32("UserID");

        //    string? name = HttpContext.Session.GetString("Name");

        //    ViewBag.name = "";

        //    // Debugging: Print values to console (check logs)
        //    Console.WriteLine($"Session Data -> UserName: {userName}, UserID: {userId}, Name is  {name}");

        //    // Check if session exists
        //    if (string.IsNullOrEmpty(userName) || userId == null)
        //    {
        //        ViewBag.UserName = "Guest"; // Default value
        //        ViewBag.UserId = 0; // Default value
        //    }
        //    else
        //    {
        //        ViewBag.UserName = userName;
        //        ViewBag.UserId = userId;
        //    }

        //    return View();
        //}

        [HttpGet]
        public IActionResult Index()
        {
            // Retrieve session values
            string? userName = HttpContext.Session.GetString("UserName");
            int? userId = HttpContext.Session.GetInt32("UserID");
            string? name = HttpContext.Session.GetString("Name");

            // Debugging: Print values to console (check logs)
            Console.WriteLine($"Session Data -> UserName: {userName}, UserID: {userId}, Name: {name}");

            // Check if session exists and set appropriate ViewBag values
            if (string.IsNullOrEmpty(userName) || userId == null || string.IsNullOrEmpty(name))
            {
                // Default values if no session data exists
                ViewBag.UserName = "Guest";
                ViewBag.UserId = 0;
                ViewBag.Name = "Unknown";
            }
            else
            {
                ViewBag.UserName = userName;
                ViewBag.UserId = userId;
                ViewBag.Name = name; // Store Name session value
            }

            return View();
        }


        // Logout: Clear session
        public IActionResult Logout()
        {
            HttpContext.Session.Clear(); // Clears session
            return RedirectToAction("Index");
        }
    }
}
