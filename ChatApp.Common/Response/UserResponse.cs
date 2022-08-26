using AutoMapper;
using ChatApp.Common.DTOs;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApp.Common.Response
{
    public class UserResponse
    {

        private IMapper _mapper;

        public UserResponse(IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        
  /*      public void UserDetailResponse(UserDetails userDetails)
        {
            var mapperConfig = new MapperConfiguration(s =>
            {
                s.CreateMap<UserDetails, ChatGroup>();
                s.CreateMap<UserDetails, Friend>();
            });
            _mapper=mapperConfig.CreateMapper();
            var userGroupRelation = _mapper.Map<UserDetails, ChatGroup>(userDetails);
            var userFriendRelation = _mapper.Map<UserDetails, Friend>(userDetails);



        }

        */





    }
}
