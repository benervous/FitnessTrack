using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;

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
        public User CurrentUser { get; }
        /// <summary>
        /// User controller.
        /// </summary>
        /// <param name="userName">User Name.</param>
        /// <param name="genderName">Gender Name.</param>
        /// <param name="birth">Birthday.</param>
        /// <param name="height">Height.</param>
        /// <param name="weight">Weight.</param>
        public UserController(string userName)
        {
            if (string.IsNullOrWhiteSpace(userName))
            {
                throw new ArgumentNullException("User name can't be null or white space", nameof(userName));
            }

            users = GetUserData();
            CurrentUser = users.SingleOrDefault(u => u.Name == userName);
            if(CurrentUser == null) { 
                CurrentUser = new User(userName);
                users.Add(CurrentUser);
                Save();
            }

           
            
        }
        /// <summary>
        /// Get user data.
        /// </summary>
        /// <returns>User data.</returns>
        public List<User> GetUserData()
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is List<User> users)
                { return users; }
                else { return new List<User>(); }
                
            }


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
