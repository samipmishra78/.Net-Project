using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using student.Models;
using Microsoft.AspNetCore.Http;

namespace student.Controllers
{
    public class HomeController : Controller
    {
        private readonly StudentDbContext context; 

        public HomeController(StudentDbContext context)
        {
            this.context = context;
        }
        public IActionResult Login()
        {

            if (HttpContext.Session.GetString("UserSession") != null) //check whether session has been created or not
            {
                return RedirectToAction("Dashboard");
            }
            return View();
        }

        [HttpPost]
        public IActionResult Login(StdDetail std)
        {

            var mystd=context.StdDetails.Where(x=> x.Email==std.Email && x.Password==std.Password).FirstOrDefault(); //if data of model and database is equal then row of that matched data is stored
            //mystd stores matched data  and if  data isnot matched then  it stores null value
            if (mystd != null) 
            {
                HttpContext.Session.SetString("usersession",mystd.Email); //session is created  when the data is matched
                return RedirectToAction("Dashboard"); // redirect from login to dashboard when data matched
            }
            else
            {
                ViewBag.Message = "Incorrect Email or Password"; //for non matching data
            }

            
            return View();
        }

        public IActionResult Logout ()
        {
            if (HttpContext.Session.GetString("usersession") != null)
            {
                HttpContext.Session.Remove("usersession"); //removes the usersession  that was created when user login
                return RedirectToAction("Login");//redirect our page to login page
            }
                return View();
        }
        public IActionResult Dashboard()
        {
            if (HttpContext.Session.GetString("usersession")!=null)
            {
                ViewBag.Mysession = HttpContext.Session.GetString("usersession").ToString(); //returns emails to dashboard  and need to typecast in viewbag and viewdata
            }
            else
            {
                return RedirectToAction("Login");
            }
            return View();
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> CreateNew(StdDetail det)
        {
            if (ModelState.IsValid) //to determine whether form is valid or not
            {
                await context.StdDetails.AddAsync(det);   // to add data to the database or create new id in app
                await context.SaveChangesAsync(); //for saving the data
                TempData["Success"] = "Registered Successfully";
                return RedirectToAction("Login");
            }

            return View();
        }

        //public IActionResult Register()
        //{
        //    return View();
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
