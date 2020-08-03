using System;
using System.Collections.Generic;
using System.Text;

namespace Fitness.BL.Model
{
    class Food
    {
        /// <summary>
        /// Name.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Calories.
        /// </summary>
        public double Calories { get; }
        /// <summary>
        /// Proteins.
        /// </summary>
        public double Proteins { get; }
        /// <summary>
        /// Fat.
        /// </summary>
        public double Fat { get; }
        /// <summary>
        /// Carbohydrates.
        /// </summary>
        public double Carbohydrates { get; }
        /// <summary>
        /// Create food by its name.
        /// </summary>
        /// <param name="Name">Name.</param>
        public Food(string Name): this(Name, 0, 0 , 0 , 0) { }
        /// <summary>
        /// Create new food.
        /// </summary>
        /// <param name="Name">Name.</param>
        /// <param name="Calories">Calories.</param>
        /// <param name="Proteins">Proteins.</param>
        /// <param name="Fat">Fat.</param>
        /// <param name="Carbohydrates">Carbohydrates.</param>
        public Food(string Name, double Calories, double Proteins, double Fat, double Carbohydrates)
        {
            #region check_input
            if (string.IsNullOrWhiteSpace(Name)) { throw new ArgumentException(("Name can't be null or white space"), nameof(Name)); }
            if (Calories <= 0) { throw new ArgumentException(("Calories can't be <=0"), nameof(Calories)); }
            if (Proteins <= 0) { throw new ArgumentException(("Proteins can't be <=0"), nameof(Proteins)); }
            if (Fat <= 0) { throw new ArgumentException(("Fat can't be <=0"), nameof(Fat)); }
            if (Carbohydrates <= 0) { throw new ArgumentException(("Calories can't be <=0"), nameof(Carbohydrates)); }
            #endregion
            this.Name = Name;
            this.Calories = Calories/100.0;
            this.Proteins = Proteins/100.0;
            this.Fat = Fat/100.0;
            this.Carbohydrates = Carbohydrates/100.0;
        }
    }
}
