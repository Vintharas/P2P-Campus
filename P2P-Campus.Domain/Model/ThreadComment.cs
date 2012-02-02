using System;

namespace P2P_Campus.Domain.Model
{
    public class ThreadComment
    {
        public virtual int Id { get; set; }

        public virtual DateTime Date { get; set; }
        public virtual string Content { get; set; }

        public virtual int ThreadId { get; set; }
        public virtual Thread Thread { get; set; }
    }
}