using System;


namespace Fitness.BL.Model
{
    [Serializable]

    /// <summary>
    /// Gender.
    /// </summary>
    public class Gender
    {
        
        /// <summary>
        /// GenderName.
        /// </summary>
        public string GenderName { get; }
        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="Name">Name.</param>
        public Gender(string GenderName)
        {
            if (string.IsNullOrWhiteSpace(GenderName))
            {
                throw new ArgumentException("The gender can't be Null or WhiteSpace", nameof(GenderName));
            }
            this.GenderName = GenderName;
        }
        /// <summary>
        /// Get Gender.
        /// </summary>
        /// <returns>Gender.</returns>
        public override string ToString()
        {
            return GenderName;
        }
    }
}
