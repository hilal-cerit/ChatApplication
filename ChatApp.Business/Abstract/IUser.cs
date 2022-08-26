using ChatApp.Common.DTOs;
using ChatApp.Common.Result;
using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUser
    {
        IResult Add(UserDTO user);
        IResult Delete(UserDTO user);
        IResult Update(UserDTO user);
        IDataResult<List<User>> GetList();
     /*   IDataResult<User> GetByID(int id);
        IDataResult<User> GetByUsername(string userName);*/









    }
}
