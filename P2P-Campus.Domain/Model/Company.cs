using System.Collections.Generic;

namespace P2P_Campus.Domain.Model
{
    public class Company
    {
        public virtual int Id { get; set; }
        
        public virtual string Name { get; set; }
        public virtual IEnumerable<Group> Groups { get; set; } 
        
    }
}