using Microsoft.AspNetCore.Mvc;

namespace Todo.Controllers
{
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public string Get()
        {
            return "Hello World it`s me Jen!";
        }
    }
}