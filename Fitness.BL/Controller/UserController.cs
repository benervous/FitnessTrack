﻿using Fitness.BL.Model;
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
                if (fs.Length >  0 && formatter.Deserialize(fs) is List<User> Users)
                { return Users; }
                else
                {
                    return new List<User>();
                }
            }
        }
        /// <summary>
        /// Set additional info for a new user
        /// </summary>
        /// <param name="gender">Gender.</param>
        /// <param name="birth">Birthday.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        public void SetAdditionalUserData(string gender,
                    DateTime birth,
                    double weight,
                    double height)
        {
            #region chech_input
            if (gender == null)
            {
                throw new ArgumentException("Gender can't be null.", nameof(gender));
            }

            if (birth < DateTime.Parse("01.01.1938") || birth > DateTime.Now)
            {
                throw new ArgumentException("Unbelieveble date of birth.", nameof(birth));
            }
            if (height <= 0)
            {
                throw new ArgumentException("Height can't be <=0.", nameof(height));
            }
            if (weight <= 0)
            {
                throw new ArgumentException("Weight can't be <=0.", nameof(weight));
            }
            #endregion
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
