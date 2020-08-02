using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// App user
    /// </summary>
    [Serializable]

    public class UserController
    {
        /// <summary>
        /// User list.
        /// </summary>
        public List<User> users { get; }
        /// <summary>
        /// CurrentUser
        /// </summary>
        public User CurrentUser { get; }
        /// <summary>
        /// Is current user new 
        /// </summary>
        public bool IsCurrentUserNew { get; } = false;
        /// <summary>
        /// UserController
        /// </summary>
        /// <param name="name">Name</param>
        public UserController(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("User name can't be null or white space", nameof(name));
            }

            users = GetUserData();
            CurrentUser = users.SingleOrDefault(u => u.Name == name);
            if (CurrentUser == null)
            {
                IsCurrentUserNew = true;
                CurrentUser = new User(name);
                users.Add(CurrentUser);
                Save();
            }
        }
        /// <summary>
        /// Get user data.
        /// </summary>
        /// <returns>User data.</returns>
        private List<User> GetUserData()
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (fs.Length != 0 && formatter.Deserialize(fs) is List<User> Users)
                { return Users; }
                else
                {
                    return new List<User>();
                }
            }
        }
        public void SetAdditionalUserData(string gender,
                    DateTime birth,
                    double weight,
                    double height)
        {
            //TODO: make checker
            CurrentUser.Gender = new Gender(gender);
            CurrentUser.Birth = birth;
            CurrentUser.Weight = weight;
            CurrentUser.Height = height;

        }
        /// <summary>
        /// Save the app user
        /// </summary>
        public void Save()
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, users);
            }
        }
    }
}
