using Microsoft.AspNetCore.Mvc;

namespace Brail_Converter.Controllers
{
    public class BrailConverterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
