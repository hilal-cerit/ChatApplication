using Business.Abstract;
using ChatApp.Common.DTOs;
using ChatApp.Common.Result;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUser
    {
        DalUser _dalUser;
        public UserManager(DalUser dalUser)
        {
            _dalUser = dalUser;
        }
        public IResult Add(UserDTO userDTO)
        {
            #region entity mapping
            User entity = new User();
            entity.UserId = userDTO.UserId;
            entity.Name= userDTO.Name;
            entity.Surname= userDTO.Surname;    
            entity.Username= userDTO.Username;  
            entity.ProfilePhoto=userDTO.ProfilePhoto;
            entity.CreateDate = userDTO.CreateDate;

            entity.Password= userDTO.Password;  
            entity.Email= userDTO.Email;    
            entity.IsActive= userDTO.IsActive;
            entity.IsAdmin=userDTO.IsAdmin;


            #endregion


            var isExist = _dalUser.GetBy(userName: userDTO.Username);

            if (isExist != null && IsPasswordStrong(userDTO.Password))
            {
                return new ErrorResult();
            }
            else
            {
                _dalUser.Add(entity);
             return new SuccessResult();
         }
        }

        public IResult Delete(UserDTO userDTO)
        {
            #region entity mapping
            User entity = new User();
            entity.UserId = userDTO.UserId;
            entity.Name = userDTO.Name;
            entity.Surname = userDTO.Surname;
            entity.Username = userDTO.Username;
            entity.ProfilePhoto = userDTO.ProfilePhoto;
            entity.CreateDate = userDTO.CreateDate;

            entity.Password = userDTO.Password;
            entity.Email = userDTO.Email;
            entity.IsActive = userDTO.IsActive;
            entity.IsAdmin = userDTO.IsAdmin;


            #endregion


            _dalUser?.Delete(entity);
            return new SuccessResult();
        }

        public IResult Update(UserDTO userDTO)
        {
            #region entity mapping
            User entity = new User();
            entity.UserId = userDTO.UserId;
            entity.Name = userDTO.Name;
            entity.Surname = userDTO.Surname;
            entity.Username = userDTO.Username;
            entity.ProfilePhoto = userDTO.ProfilePhoto;
            entity.CreateDate = userDTO.CreateDate;

            entity.Password = userDTO.Password;
            entity.Email = userDTO.Email;
            entity.IsActive = userDTO.IsActive;
            entity.IsAdmin = userDTO.IsAdmin;


            #endregion
            // var loginResult = Login(userDTO.Username,userDTO.Password);

            if (_dalUser.Login(userDTO.Username, userDTO.Password))
            {
                _dalUser.Update(entity);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult("Please check your username or password!");
            }

        }


        
        public IDataResult<User> GetByID(int id){
            
            return new SuccessDataResult<User>(_dalUser.GetBy(id:id));
        }


        public IDataResult<User> GetByUsername(string userName)
        {
            return new SuccessDataResult<User>(_dalUser.GetBy(userName:userName));
            ;
        }
        

        public IDataResult<List<User>> GetList()
        {
            return new SuccessDataResult<List<User>>(_dalUser.GetAll());
        }


        //validasyon
        public static bool IsPasswordStrong(string password)
        {
            return Regex.IsMatch(password, @"^.*(?=.{7,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^a-zA-Z0-9]).*$");
        }










    }
}
