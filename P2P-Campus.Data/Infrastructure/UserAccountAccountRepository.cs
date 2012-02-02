using System;
using System.Collections.Generic;
using System.Linq;
using P2P_Campus.Data.Interfaces;
using P2P_Campus.Domain.Model;

namespace P2P_Campus.Data.Infrastructure
{
    /// <summary>
    /// Class that represents a user repository
    /// </summary>
    public class UserAccountAccountRepository : IUserAccountRepository
    {
        static private IDictionary<string, User> users = new Dictionary<string, User>();
        private const int BCRYPT_FACTOR = 10;

        /// <summary>
        /// Check whether a username/password pair is valid
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public bool IsValidLogin(string username, string password)
        {
            return users.ContainsKey(username) && VerifyPassword(username, password);
        }

        /// <summary>
        /// Verify user password
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool VerifyPassword(string username, string password)
        {
            return BCrypt.Net.BCrypt.Verify(password, users[username].Password);
        }

        /// <summary>
        /// Check whether a username is available
        /// </summary>
        /// <param name="username"></param>
        /// <returns></returns>
        public bool IsAvailable(string username)
        {
            return !users.ContainsKey(username);
        }

        /// <summary>
        /// Add a new user
        /// </summary>
        /// <param name="newUser"></param>
        public void Add(User newUser)
        {
            newUser.Password = HashPassword(newUser.Password);
            users.Add(newUser.Username, newUser);
        }

        /// <summary>
        /// Hash a password given by the user
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, BCRYPT_FACTOR);
        }

        /// <summary>
        /// Get based on a constraint
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public User Get(Func<User, bool> condition)
        {
            return users.Values.Where(condition).FirstOrDefault();
        }

        /// <summary>
        /// Change password associated to a user
        /// </summary>
        /// <param name="username"></param>
        /// <param name="newPassword"></param>
        public void ChangePassword(string username, string newPassword)
        {
            User user = Get(u => u.Username == username);
            user.Password = HashPassword(newPassword);
        }
    }
}