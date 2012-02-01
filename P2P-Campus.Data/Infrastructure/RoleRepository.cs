using System.Collections.Generic;
using P2P_Campus.Data.Interfaces;

namespace P2P_Campus.Data.Infrastructure
{
    /// <summary>
    /// Class that represents a role repository
    /// </summary>
    public class RoleRepository : IRoleRepository
    {
        public IEnumerable<string> GetRoles(string username)
        {
            throw new System.NotImplementedException();
        }
    }
}