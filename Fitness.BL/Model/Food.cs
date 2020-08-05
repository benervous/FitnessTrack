using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    [Serializable]
    /// <summary>
    /// Food.
    /// </summary>
    public class Food
    {
        /// <summary>
        /// Food_Name.
        /// </summary>
        public string Food_Name { get; }
        /// <summary>
        /// Calories per 1 gramm.
        /// </summary>
        public double Calories { get; }
        /// <summary>
        /// Proteins per 1 gramm.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fat per 1 gramm.
        /// </summary>
        public double Fat { get; }
         /// <summary>
        /// Carbohydrates per 1 gramm.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Create food by its name with default params.
        /// </summary>
        /// <param name="Name">Food_Name.</param>
        public Food(string Food_Name): this(Food_Name, 0, 0 , 0 , 0) { }
        /// <summary>
        /// Create new food and initialize params as param per 100 gramm.
        /// </summary>
        /// <param name="Food_Name">Name of food.</param>
        /// <param name="Calories">Calories per 100 gramm.</param>
        /// <param name="Proteins">Proteins per 100 gramm.</param>
        /// <param name="Fat">Fat per 100 gramm.</param>
        /// <param name="Carbohydrates">Carbohydrates per 100 gramm.</param>
        public Food(string Food_Name, double Calories, double Proteins, double Fat, double Carbohydrates)
        {
            #region check_input
            if (string.IsNullOrWhiteSpace(Food_Name)) { throw new ArgumentException(("Name can't be null or white space"), nameof(Food_Name)); }
            if (Calories <= 0) { throw new ArgumentException(("Calories can't be <=0"), nameof(Calories)); }
            if (Proteins <= 0) { throw new ArgumentException(("Proteins can't be <=0"), nameof(Proteins)); }
            if (Fat <= 0) { throw new ArgumentException(("Fat can't be <=0"), nameof(Fat)); }
            if (Carbohydrates <= 0) { throw new ArgumentException(("Calories can't be <=0"), nameof(Carbohydrates)); }
            #endregion
            this.Food_Name = Food_Name;
            this.Calories = Calories/100.0;
            this.Proteins = Proteins/100.0;
            this.Fat = Fat/100.0;
            this.Carbohydrates = Carbohydrates/100.0;
        }
    }
}
