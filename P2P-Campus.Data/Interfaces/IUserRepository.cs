namespace P2P_Campus.Data.Interfaces
{
    /// <summary>
    /// Interface that represents a contract for a user repository
    /// </summary>
    public interface IUserRepository
    {
        bool IsValidLogin(string username, string password);
    }
}