using Fitness.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Fitness.BL.Controller
{
    class EatingController:ControllerBase
    {
        private const string FILE_NAME_FOOD = "food.dat";
        private const string FILE_NAME_EATING = "eating.dat";
        public readonly User User;
        public List<Food> Food { get; }
        public List<Eating> Eating { get; }
        public EatingController(User User)
        {
            this.User = User ?? throw new ArgumentNullException(("User can't be null"), nameof(User));
            Food = GetAllFood();
            Eating = GetAllEating();
        }
        private List<Eating> GetAllEating()
        {
            return Load<List<Eating>>(FILE_NAME_EATING) ?? new List<Eating>();
        }
        private List<Food> GetAllFood()
        {
            return Load<List<Food>>(FILE_NAME_FOOD) ?? new List<Food>();
        }
        private void Save()
        {
            Save(FILE_NAME_FOOD, Food);
            Save(FILE_NAME_EATING, Eating);
        }
        //public bool Add(string Name, double weight)
        //{
        //    var food = Food.SingleOrDefault(f => f.Name == Name);
        //    var eating = new Eating(User);
        //    if(food != null)
        //    {
        //        Eating.Add();
        //    }

        //}
    }
}
