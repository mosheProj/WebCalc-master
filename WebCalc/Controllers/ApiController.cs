using Microsoft.AspNetCore.Mvc;
using WebCalc.Interfaces;
using WebCalc.Models;


namespace WebCalc.Controllers
{

    [Route("api")]
    public class ApiController : Controller
    {

        private readonly ICalculateService _serv;

        public ApiController(ICalculateService serv)
        {
            _serv = serv;
        }
        

        [HttpPost("calculate")]
        public IActionResult CalcResult([FromBody]CalculationRequest request)
        {
            var response = _serv.Evaluate(request);

            return Json(new
            {
                result = response != null ?  response.Result.ToString() : "Invalid expression",
            });
        }
    }
}
