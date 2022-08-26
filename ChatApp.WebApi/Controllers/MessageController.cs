using Business.Concrete;
using ChatApp.Common.DTOs;
using ChatApp.DataLayer.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ChattApp.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class MessageController : Controller
    {
        MessageManager _messageManager;
        public MessageController(MessageManager messageManager)
        {
            _messageManager = messageManager;
        }

        [Route("GetPrivateMessage")]
        [HttpGet]
        public IActionResult GetPrivateMessage([FromBody] int senderID, int receiverID)
        {

            return Ok(_messageManager.GetPrivateMessage(senderID,  receiverID));

        }


        [Route("SendMessage")]
        [HttpPost]
        public IActionResult SendMessage([FromBody] MessageDTO messageDTO)
        {
            var result = _messageManager.SendMessage(messageDTO);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();


        }
        /*
      


        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(UserDTO userDTO,Message message)
        {
            var result = _messageManager.Delete(userDTO,message);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();

        }




        [Route("GetGroupMessage")]
        [HttpGet]
        public IActionResult GetGroupMessage()
        {
          
                return Ok();
           
        }

        */

    }
}
