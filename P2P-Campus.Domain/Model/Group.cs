using System.Collections.Generic;

namespace P2P_Campus.Domain.Model
{
    public class Group
    {
        public virtual int Id { get; set; }

        public virtual string Name { get; set; }
        public virtual IEnumerable<User> Users { get; set; }

        public virtual int CompanyId { get; set; }
        public virtual Company Company { get; set; }
    }
}