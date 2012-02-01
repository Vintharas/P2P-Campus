using System.Collections.Generic;

namespace P2P_Campus.Data.Interfaces
{
    /// <summary>
    /// Interface that represents a contract for a role repository
    /// </summary>
    public interface IRoleRepository
    {
        IEnumerable<string> GetRoles(string username);
    }
}