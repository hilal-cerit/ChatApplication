using Business.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FriendController : Controller
    {
        FriendManager _friendManager;
        public FriendController(FriendManager friendManager)
        {
            _friendManager = friendManager; 
        }
    }
}
