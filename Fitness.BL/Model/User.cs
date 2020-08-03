using System;



namespace Fitness.BL.Model

{
    /// <summary>
    /// User
    /// </summary>
    [Serializable]
    public class User
    {
        #region properties
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Gender.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// BirthDate.
        /// </summary>
        public DateTime Birth { get; set; }
        /// <summary>
        /// Weight.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Height.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Age.
        /// </summary>
        public int Age { get { return DateTime.Now.Year - Birth.Year; } }
        #endregion
        /// <summary>
        /// Create new user from Data.
        /// </summary>
        /// <param name="name">Name.</param>
        /// <param name="gender">Gender.</param>
        /// <param name="birth">BirthDate.</param>
        /// <param name="weight">Weight.</param>
        /// <param name="height">Height.</param>
        public User(string name,
                    Gender gender,
                    DateTime birth,
                    double weight,
                    double height)
        {
            #region check_input
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name can't be Null or WhiteSpace.", nameof(name));
            }
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
            Name = name;
            Gender = gender;
            Birth = birth;
            Weight = weight;
            Height = height;
        }
        /// <summary>
        /// Create absolute new user.
        /// </summary>
        /// <param name="name">Name.</param>
        public User(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("The name can't be Null or WhiteSpace.", nameof(name));
            }
            Name = name;

        }
        /// <summary>
        /// Get user info.
        /// </summary>
        /// <returns>UserName, Age..</returns>
        public override string ToString()
        {
            return $"Name:{Name}, Age: {Age}, {Birth}";
        }
    }
}
