using System;

namespace Fitness.BL.Model
{
    class Gender
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Create new gender.
        /// </summary>
        /// <param name="Name">Name.</param>
        public Gender(string Name)
        {
            if (string.IsNullOrWhiteSpace(Name))
            {
                throw new ArgumentException("The gender can't be Null or WhiteSpace", nameof(Name));
            }
            this.Name = Name;
        }
        /// <summary>
        /// Get Name.
        /// </summary>
        /// <returns>Name.</returns>
        public override string ToString()
        {
            return Name;
        }
    }
}
