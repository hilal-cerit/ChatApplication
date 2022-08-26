
using Business.Concrete;
using ChatApp.Common.DTOs;
using ChatApp.DataLayer.Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChattApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {

        
       UserManager _userManager;
        public UserController(UserManager userManager)
        {
            _userManager=userManager;
        }

         [HttpGet("GetAllUsers")]
         public IActionResult GetAll()
         {
            
             return Ok(_userManager.GetList());
         }
        

        [Route("Add")]
        [HttpPost]
        public IActionResult Create([FromBody]UserDTO userDTO)
        {
            var result = _userManager.Add(userDTO);
                   if (result.Success==true)
            {
                  return Ok();
            }

            return BadRequest();


        }


        [Route("Delete")]
        [HttpDelete]
        public IActionResult Delete(UserDTO userDTO)
        {
            var result = _userManager.Delete(userDTO);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();

        }




        [Route("Update")]
        [HttpPut]
        public IActionResult Update([FromBody] UserDTO userDTO)
        {
            var result = _userManager.Update(userDTO);
            if (result.Success == true)
            {
                return Ok();
            }

            return BadRequest();
        }



        [Route("GetById")]
        [HttpGet]
        public IActionResult GetById(int userId)
        {

           
            return Ok(_userManager.GetByID(userId));
        }


        [HttpGet("FindByName")]
        public IActionResult FindByName(string userName)
        {
            return Ok(_userManager.GetByUsername(userName));
        }

        //PM> Scaffold-DbContext "Server=(local)\MSSQLLocalDB;Database=ChatAppDB" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DataLayer*/
    }


}

