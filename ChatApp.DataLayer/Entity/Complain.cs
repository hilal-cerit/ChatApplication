using ChatApp.Common.Entity;
using System;
using System.Collections.Generic;

namespace ChatApp.DataLayer.Entity
{
    public partial class Complain:IEntity
    {
        public int ComplainId { get; set; }
        public int ComplainantUserId { get; set; }
        public int ComplainedOfUserId { get; set; }
        public byte ComplainStatusId { get; set; }
        public DateTime ComplainDate { get; set; }
        public int? MessageReferenceId { get; set; }

        public virtual ComplainStatus ComplainStatus { get; set; } = null!;
        public virtual User ComplainantUser { get; set; } = null!;
        public virtual User ComplainedOfUser { get; set; } = null!;
    }
}
