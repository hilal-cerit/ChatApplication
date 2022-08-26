using ChatApp.Common.Result;
using ChatApp.DataLayer.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface  IFriend
    {

        IResult Add(Friend friend);
        IResult Delete(Friend friend);
        IResult Update(Friend friend);

    }
}
