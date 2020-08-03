using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Controller
{
    class EatingController:ControllerBase
    {
        #region properties.
        /// <summary>
        /// Food file name.
        /// </summary>
        private const string FILE_NAME_FOOD = "food.dat";
        /// <summary>
        /// Eating file name.
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
        /// Eating controller.
        /// </summary>
        /// <param name="User"></param>
        public EatingController(User User)
        {
            this.User = User ?? throw new ArgumentNullException(("User can't be null"), nameof(User));
            Food = GetAllFood();
            Eating = GetEating();
        }
        /// <summary>
        /// Get Eating.
        /// </summary>
        /// <returns>Eating dictionary.</returns>
        private Eating GetEating()
        {
            return Load<Eating>(FILE_NAME_EATING) ?? new Eating(User);
        }
        /// <summary>
        /// Get Food Collection.
        /// </summary>
        /// <returns>Food list.</returns>
        private List<Food> GetAllFood()
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
        /// Add food by it's name.
        /// </summary>
        /// <param name="Name"></param>
        /// <param name="weight"></param>
        /// <returns>True.</returns>
        public bool Add(string Name, double weight)
        {
            var food = Food.SingleOrDefault(f => f.Name == Name);
            if (food != null)
            {
                Eating.Add(food, weight);
                Save();
                return true;
            }
            return false;

        }
        /// <summary>
        /// Add food by its type.
        /// </summary>
        /// <param name="Food"></param>
        /// <param name="weight"></param>
        public void Add(Food Food, double weight)
        {
            var product = this.Food.SingleOrDefault(f=>f.Name == Food.Name);
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
