using Microsoft.AspNetCore.Mvc;

namespace Library.Services
{
    public class AuthMessageSenderOptions : Controller
    {
        public string? SendGridKey { get; set; }

        public IActionResult Index()
        {
            return View();
        }
    }
}
