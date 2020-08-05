using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Eating.
    /// </summary>
    public class Eating
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
        /// Collecion of food_name and weight.
        /// </summary>
        public Dictionary<Food, double> Food { get; }
        /// <summary>
        /// Create eating process.
        /// </summary>
        /// <param name="User">User.</param>
        public Eating(User User)
        {

            this.User = User ?? throw new ArgumentException(("User can't be null"), nameof(User));
            Moment = DateTime.UtcNow;
            Food = new Dictionary<Food, double>();
        }
        /// <summary>
        /// Add food to a food collection.
        /// </summary>
        /// <param name="food">Food name.</param>
        /// <param name="weight">Food weight.</param>
        public void Add(Food food, double weight)
        {
            var product = Food.Keys.FirstOrDefault(f => f.Food_Name.Equals(food));
            if (product == null)
            {
                Food.Add(food, weight);
            }
            else
            {
                Food[product] += weight;
            }
        }
    }
}
