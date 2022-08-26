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
    public class GroupManager : IGroup
    {

        public DalGroup _dalGroup;

        public GroupManager(DalGroup dalGroup)
        {
            _dalGroup = dalGroup;
        }

        public IResult Add(GroupMember groupMember,Group group)
        {
            //tek bir gruba üye olabilir gibi oldu yanlış
            if (groupMember.GroupId == group.GroupId)
            { _dalGroup.Add(group);
                return new SuccessResult();
            }
            else
                return new ErrorResult();
        }

        public IResult Delete(GroupMember groupMember,Group group)
        {
            if(group.CreaterUser.UserId==groupMember.GroupMemberId)
            {
                _dalGroup.Delete(group);
                return new SuccessResult();
            }
            else
            {
                return new ErrorResult();   
            }

        }

      /*  public ChatGroup GetGroupDetail()
        {
            return _dalGroup.Get();
        }
      */
        public IResult Update(GroupMember groupMember,Group group)
        {
           if(groupMember.IsAdmin)
            {
                _dalGroup.Update(group);

                return new SuccessResult();
            }

            else
            {
                return new ErrorResult();
            }
           
        }

     
    }
}
