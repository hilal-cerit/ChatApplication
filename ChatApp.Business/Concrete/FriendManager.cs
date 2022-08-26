using Business.Abstract;
using ChatApp.Common.Result;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FriendManager : IFriend

    {
        DalFriend _dalFriend;

        public FriendManager(DalFriend dalFriend)
        {
            _dalFriend = dalFriend;
        }

        public IResult Add(Friend friend)
        {
          
            _dalFriend.Add(friend);
            return new SuccessResult();
        }

        public IResult Delete(Friend friend)
        {
            _dalFriend.Delete(friend);
            return new SuccessResult();
        }

  

        public IResult Update(Friend friend)
        {
           _dalFriend.Update(friend);
            return new SuccessResult();
        }
    }
}
