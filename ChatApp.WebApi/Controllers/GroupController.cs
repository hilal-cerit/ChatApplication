using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GroupController : Controller
    {
        GroupManager _groupManager;

        public GroupController(GroupManager groupManager)
        {
            _groupManager = groupManager;   
        }
    }
}
