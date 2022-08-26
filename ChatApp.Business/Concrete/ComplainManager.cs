using Business.Abstract;
using ChatApp.Common.Result;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ComplainManager : IComplain
    {
        DalComplain _dalComplain;
        public ComplainManager(DalComplain dalComplain)
        {
            _dalComplain = dalComplain;
        }


        public IResult Add(Complain complain)
        {
            if(complain.ComplainStatusId == null)
            {
                return new ErrorResult("Please choose your complain reason");
            }
            else { 
                
                _dalComplain.Add(complain);
                return new SuccessResult();
            }
          
        }

        public IResult Delete(Complain complain)
        {
            _dalComplain.Delete(complain);
            return new SuccessResult();
        }

        public IDataResult<List<Complain>> GetAll()
        {
          
            return new SuccessDataResult<List<Complain>>(_dalComplain.GetAll());

        }

        public IResult Update(Complain complain)
        {
            _dalComplain.Update(complain);
            return new SuccessResult();
        }


        /*şikayet edilme aralığını alacaksak if te belirli tarihteki ıd lerin üstünden geçip ortak var mı diye kontrol edebiliriz???
        public static bool ChechIfChattedBefore(User sikayeteden,User sikayetedilen)
        {
            if (sikayeteden.ComplainComplainantUsers )
            {

                return true;
            }
        */
           
        }

    }

