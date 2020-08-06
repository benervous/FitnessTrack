using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Controller
{
    /// <summary>
    /// Eating controller.
    /// </summary>
    public class EatingController:ControllerBase
    {
        #region properties.
        /// <summary>
        /// Food data file name.
        /// </summary>
        private const string FILE_NAME_FOOD = "food.dat";
        /// <summary>
        /// Eating data file name.
        /// </summary>
        private const string FILE_NAME_EATING = "eating.dat";
        /// <summary>
        /// User.
        /// </summary>
        public readonly User User;
        /// <summary>
        /// Food collection.
        /// </summary>
        public List<Food> Food { get; }
        /// <summary>
        /// Eating.
        /// </summary>
        public Eating Eating { get; }
        #endregion
        /// <summary>
        /// User's eating.
        /// </summary>
        /// <param name="User"></param>
        public EatingController(User User)
        {
            this.User = User ?? throw new ArgumentNullException(("User can't be null"), nameof(User));
            Food = GetFood();
            Eating = GetEating();
        }
        /// <summary>
        /// Get Eating.
        /// </summary>
        /// <returns>Existing eating dictionary or new eating.</returns>
        private Eating GetEating()
        {
            return Load<Eating>(FILE_NAME_EATING) ?? new Eating(User);
        }
        /// <summary>
        /// Get Food.
        /// </summary>
        /// <returns>Existing food list or new food list.</returns>
        private List<Food> GetFood()
        {
            return Load<List<Food>>(FILE_NAME_FOOD) ?? new List<Food>();
        }
        /// <summary>
        /// Save Data.
        /// </summary>
        private void Save()
        {
            Save(FILE_NAME_FOOD, Food);
            Save(FILE_NAME_EATING, Eating);
        }  
        /// <summary>
        /// Add new food if it's not exist in the food list or add it if it exists.
        /// </summary>
        /// <param name="Food">Food object.</param>
        /// <param name="weight">Food weight.</param>
        public void Add(Food Food, double weight)
        {
            if(weight <=0 ) { throw new ArgumentNullException(("Weight can't be <=0"), nameof(weight)); }

            var product = this.Food.SingleOrDefault(f=>f.Food_Name == Food.Food_Name);
            if(product == null)
            {
                this.Food.Add(Food);
                Eating.Add(Food, weight);
                Save();
            }
            else
            {
                Eating.Add(product, weight);
                Save();
            }
        }
    }
}
