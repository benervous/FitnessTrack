using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Fitness.BL.Model
{
    /// <summary>
    /// Eating.
    /// </summary>
    class Eating
    {
        /// <summary>
        /// User.
        /// </summary>
        public User User { get; }
        /// <summary>
        /// Moment.
        /// </summary>
        public DateTime Moment { get; }
        /// <summary>
        /// List of food and weight.
        /// </summary>
        public Dictionary<Food, double> Foods { get; }
        /// <summary>
        /// Create eating process.
        /// </summary>
        /// <param name="User">User.</param>
        public Eating(User User)
        {

            this.User = User ?? throw new ArgumentException(("User can't be null"), nameof(User));
            Moment = DateTime.UtcNow;
            Foods = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Add food.
        /// </summary>
        /// <param name="food">Food.</param>
        /// <param name="weight">Weight.</param>
        public void Add(Food food, double weight)
        {
            var product = Foods.Keys.FirstOrDefault(f => f.Name.Equals(food));
            if (product == null)
            {
                Foods.Add(product, weight);
            }
            else
            {
                Foods[product] += weight;
            }
        }
    }
}
