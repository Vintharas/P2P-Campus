using System.Collections.Generic;



namespace P2P_Campus.Domain.Model
{
    public class User
    {
        public virtual int Id { get; set; }

        public virtual string Username { get; set; }
        public virtual string Password { get; set; }

        public virtual string FullName { get; set; }
        public virtual string Email { get; set; }
        public virtual string Biography { get; set; }
        public virtual byte[] Avatar { get; set; }

        public virtual IEnumerable<Thread> WallThreads { get; set; }

        public virtual IEnumerable<Group> Groups { get; set; }
    }
}