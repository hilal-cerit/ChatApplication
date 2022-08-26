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
    public interface  IMessage
    {
        IResult SendMessage(MessageDTO message);
        IResult Delete(UserDTO userDTO, MessageDTO message);

        IDataResult<List<Message>>  GetGroupMessage(int senderID, int groupID);
        IDataResult<List<Message>>  GetPrivateMessage(int senderID, int receiverID);

    }
}
