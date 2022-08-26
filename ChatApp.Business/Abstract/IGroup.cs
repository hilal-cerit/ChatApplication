using ChatApp.Common.Result;
using ChatApp.DataLayer.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IGroup
    {
        IResult Add(GroupMember groupMember,Group group);
        IResult Delete(GroupMember groupMember,Group group);
        IResult Update(GroupMember groupMember,Group group);
      //  ChatGroup GetGroupDetail(int groupId);
    }
}
