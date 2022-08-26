using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ComplainController : Controller
    {
        ComplainManager _complainManager;
        public ComplainController(ComplainManager complainManager)
        {
            _complainManager=complainManager;
        }
    }
}
