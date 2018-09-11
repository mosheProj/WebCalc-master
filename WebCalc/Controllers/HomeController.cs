using Microsoft.AspNetCore.Mvc;
using WebCalc.Interfaces;

namespace WebCalc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculateService _serv;

        public HomeController(ICalculateService serv)
        {
            _serv = serv;
            //Eb
        }

        public IActionResult Index()
        {
            return View();
        }
         
    }
}
