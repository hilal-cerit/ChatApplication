﻿using ChatApp.Common.Entity;
using System;
using System.Collections.Generic;

namespace ChatApp.DataLayer.Entity
{
    public partial class FriendStatus : IEntity
    {
        public FriendStatus()
        {
            Friends = new HashSet<Friend>();
        }

        public byte FriendStatusId { get; set; }
        public string StatusDescription { get; set; } = null!;

        public virtual ICollection<Friend> Friends { get; set; }
    }
}
