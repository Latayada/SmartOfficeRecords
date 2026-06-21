using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;
using SmartOfficeRecords.Models;

namespace SmartOfficeRecords.Controllers
{
    public class AdminController : Controller
    {
        //GeET: Admin/Login
        public ActionResult Login()
        {
            return View();
        } 

        // POST: Admin/AdminLogin
        [HttpPost]
        public IActionResult Login(string Username, string Password)
        {
            // SAMPLE LOGIN
            if (Username == "admin" && Password == "admin1234")
            {
                // GO TO DASHBOARD
                return RedirectToAction("Dashboard");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        // DASHBOARD
        public IActionResult Dashboard()
        {
            return View();
        }

        public ActionResult RequestManagement()
        {
            return View();
        }
        public ActionResult RecordsManagement()
        {
            return View();
        }
        public ActionResult ReportsManagement()
        {
            return View();
        }
        public ActionResult UsersManagement()
        {
            return View();
        }
        public ActionResult Settings()
        {
            return View();
        }

        public ActionResult SAccountSettings()
        {
            var admin = new AdminViewModel
            {
                FullName = "Juan Dela Cruz",
                Username = "admin",
                Email = "admin@sors.com",
                Phone = "09123456789"
            };

            return View(admin);
        }

        //GET: Admin/RequestManagement/CreateRequest
        public ActionResult RCreateRequest()
        {
            return View();
        }

      
       

        //GET: Admin/UserManagement/AddNewUser
        public ActionResult AddNewUser()
        {
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(
             string Fullname,
             string Username,
             string Email,
             string Contact,
             string Address,
             string Department,
             string Password,
             string ConfirmPassword,
             IFormFile ProfileImage)
        {
            // PASSWORD CHECK
            if (Password != ConfirmPassword)
            {
                ViewBag.Error = "Password does not match.";
                return View();
            }

            // CHECK IMAGE
            if (ProfileImage != null)
            {
                string fileName =
                    System.IO.Path.GetFileName(ProfileImage.FileName);

                string path =
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ProfileImage.CopyTo(stream);
                }
            }

            ViewBag.Success = "Registered Successfully!";

            return View();
        }
    }
}