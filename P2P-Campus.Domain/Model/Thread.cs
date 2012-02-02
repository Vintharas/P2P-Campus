using System;
using System.Collections.Generic;

namespace P2P_Campus.Domain.Model
{
    public class Thread
    {
        public virtual int Id { get; set; }

        public virtual DateTime Date { get; set; }
        public virtual string Content { get; set; }

        public virtual int UserId { get; set; }
        public virtual User User { get; set; }

        public virtual IEnumerable<ThreadComment> Comments { get; set; } 
      
    }
}