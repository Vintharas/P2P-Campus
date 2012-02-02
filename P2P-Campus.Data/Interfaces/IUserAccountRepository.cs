using System;
using P2P_Campus.Domain.Model;

namespace P2P_Campus.Data.Interfaces
{
    /// <summary>
    /// Interface that represents a contract for a user repository
    /// </summary>
    public interface IUserAccountRepository
    {
        bool IsValidLogin(string username, string password);
        bool IsAvailable(string username);
        void Add(User newUser);
        User Get(Func<User, bool> condition);
        void ChangePassword(string username, string newPassword);
    }
}