using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Mvc;

namespace SmartOfficeRecords.Controllers
{
    public class ApplicantController : Controller
    {
        // GET: Applicant/ApplicantLogin
        public ActionResult ApplicantLogin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplicantLogin(
            string Username,
            string Password)
        {
            // SAMPLE LOGIN
            if (Username == "applicant" &&
                Password == "12345")
            {
                return RedirectToAction("Applicant");
            }

            ViewBag.Error =
                "Invalid Username or Password";

            return View();
        }

        // GET: Applicant/ApplicantRegister
        public ActionResult ApplicantRegister()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ApplicantRegister(
            string Fullname,
            string Username,
            string Email,
            string ContactNumber,
            string Birthdate,
            string InvitedBy,
            string Password,
            string ConfirmPassword,
            IFormFile ProfileImage)
        {
            // PASSWORD VALIDATION
            if (Password != ConfirmPassword)
            {
                ViewBag.Error =
                    "Password does not match.";

                return View();
            }

            // SAVE IMAGE
            if (ProfileImage != null)
            {
                string fileName =
                    System.IO.Path.GetFileName(
                        ProfileImage.FileName);

                string path =
                    Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/Uploads", fileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    ProfileImage.CopyTo(stream);
                }
            }

            ViewBag.Success =
                "Registered Successfully!";

            return View();
        }

        public ActionResult ApplicantDash()
        {
            return View();
        }
    }
}