
using ChatApp.Common.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Common.DTOs
{
    public  class UserDTO: IDto
    {
        public int UserId { get; set; } 
        public string Name { get; set; }
        public string Surname { get; set; } = null!;
        public string? Username { get; set; }
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? ProfilePhoto { get; set; }
        public DateTime CreateDate { get; set; }
        public bool IsActive { get; set; }
        public bool? IsAdmin { get; set; }


    }
}
