using Microsoft.AspNetCore.Mvc;

namespace SmartOfficeRecords.Controllers
{
    public class StaffController : Controller
    {
        // GET: Staff Login Page
        [HttpGet]
        public ActionResult StaffLogin()
        {
            return View();
        }

        // POST: Staff Login
        [HttpPost]
        public IActionResult StaffLogin(string Username, string Password)
        {
            if (Username == "staff" && Password == "123")
            {
                return RedirectToAction("StaffDashboard", "Staff");
            }

            ViewBag.Error = "Invalid Username or Password";
            return View();
        }

        public IActionResult StaffDashboard()
        {
            return View();
        }

        public IActionResult StaffRecords()
        {
            return View();
        }

        // GET: Staff/RecordsManagement
        public ActionResult StaffUploadFiles()
        {
            return View();
        }

        public ActionResult StaffUploadDetails()
        {
            return View();
        }

        public ActionResult StaffUploadReviewConfirm()
        {
            return View();
        }

        public ActionResult StaffRequest()
        {
            return View();
        }
    }
}
