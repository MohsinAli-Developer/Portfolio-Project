using Microsoft.AspNetCore.Mvc;
using SampleProject.Models;

namespace SampleProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;

        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        public IActionResult Index()
        {
            ViewData["Title"] = "Home | Mohsin Ali - .NET Developer";
            ViewData["Description"] = "Junior .NET Developer with 1+ years experience in ASP.NET Core, Flutter, and React. View my portfolio, projects, and professional journey.";
            ViewData["CanonicalUrl"] = $"{Request.Scheme}://{Request.Host}/";
            ViewData["OgImage"] = $"{Request.Scheme}://{Request.Host}/images/profile-og.jpg";

            return View();
        }

        public IActionResult Projects()
        {
            ViewData["Title"] = "Projects | Mohsin Ali - Portfolio";
            ViewData["Description"] = "Explore my software development projects including ERP System, Garbage Complaint Management System, and IoT Water Quality Monitoring System.";
            ViewData["CanonicalUrl"] = $"{Request.Scheme}://{Request.Host}/Home/Projects";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact | Mohsin Ali - Get in Touch";
            ViewData["Description"] = "Contact Mohsin Ali for collaboration, job opportunities, or questions about .NET development projects.";
            ViewData["CanonicalUrl"] = $"{Request.Scheme}://{Request.Host}/Home/Contact";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Contact(ContactViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Here you would implement email sending logic
                TempData["SuccessMessage"] = "Thank you! I'll get back to you soon.";
                return RedirectToAction(nameof(Contact));
            }
            return View(model);
        }
    }
}