using System.Collections.Generic;
using P2P_Campus.Data.Interfaces;
using P2P_Campus.Domain.Model;

namespace P2P_Campus.Data.Infrastructure
{
    /// <summary>
    /// Class that represents a user repository
    /// </summary>
    public class UserRepository : IUserRepository
    {
        private IDictionary<string, User> users;

        public UserRepository()
        {
            users = new Dictionary<string, User>();
            users.Add("jaime", new User {Username = "jaime", Password = "jaime"});
        }

        /// <summary>
        /// Check whether a username/password pair is valid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidLogin(string username, string password)
        {
            return users.ContainsKey(username) && users[username].Password == password;
        }
    }
}