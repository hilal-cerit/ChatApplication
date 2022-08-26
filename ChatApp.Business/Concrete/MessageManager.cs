using Business.Abstract;
using ChatApp.Common.DTOs;
using ChatApp.Common.Result;
using ChatApp.DataLayer;
using ChatApp.DataLayer.Entity;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

namespace Business.Concrete
{
    public class MessageManager : IMessage

    {
        DalMessage _dalMessage;
        public MessageManager(DalMessage dalMessage)
        {
            _dalMessage = dalMessage;
           
        }


        public IResult Delete(UserDTO userDTO, MessageDTO messageDTO)
        {
            #region entity mapping
            Message message = new Message();
            message.MessageId = messageDTO.MessageId;
            message.SenderId = messageDTO.SenderId;
            message.ReceiverId = messageDTO.ReceiverId;
            message.GroupId = messageDTO.GroupId;
            message.MessageContent = messageDTO.MessageContent;
           
            #endregion


            var isExist = _dalMessage.Get(p=>(p.Sender.UserId== userDTO.UserId) && (p.MessageId==message.MessageId));
           if (isExist!=null)
           {

              _dalMessage.Delete(message);
              return new SuccessResult();
            }
           else
                return new ErrorResult(); 
        }

        public IDataResult<List<Message>>  GetGroupMessage(int senderID, int groupID)
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<Message>>  GetPrivateMessage(int senderID, int receiverID)
        {
        

            return new SuccessDataResult<List<Message>>(_dalMessage.GetAll(p => (p.SenderId == senderID) && (p.ReceiverId == receiverID)));
          

        }

        public IResult SendMessage(MessageDTO messageDTO)
        {
            #region entity mapping
            Message message = new Message();
            message.MessageId = messageDTO.MessageId;
            message.SenderId = messageDTO.SenderId;
            message.ReceiverId = messageDTO.ReceiverId;
            message.GroupId = messageDTO.GroupId;
            message.MessageContent = messageDTO.MessageContent;
         
            #endregion


            if (message == null)
            {
                return new ErrorResult();
            }
            else
            {
                _dalMessage.Add(message);

                return new SuccessResult();
            }
        }
    }
}
