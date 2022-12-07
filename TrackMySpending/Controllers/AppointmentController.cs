using Microsoft.AspNetCore.Mvc;

namespace TrackMySpending.Controllers
{
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            string todaysDate = DateTime.Now.ToShortDateString();
            return View();
        }
    }
}
