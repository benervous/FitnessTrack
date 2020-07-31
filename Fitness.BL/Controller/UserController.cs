using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
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
        /// User.
        /// </summary>
        public User user { get; }
        public UserController(string userName, string genderName, DateTime birth, 
            double height, double weight)
        {
            //TODO: checker

            var gender = new Gender(genderName);
            user = new User(userName, gender, birth, weight, height);
            
        }
        public UserController()
        {
            var formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("users.dat", FileMode.OpenOrCreate))
            {
                if (formatter.Deserialize(fs) is User user)
                { this.user = user; }
                // TODO:  what if user load was failed
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
                formatter.Serialize(fs, user);
            }
        }
     
       

    }
}
