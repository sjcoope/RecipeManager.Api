using SJCNet.RecipeManager.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Model
{
    public class Recipe : IEntity
    {
        public Recipe()
        {
            Steps = new List<Step>();
            Ingredients = new List<Ingredient>();
            Tags = new List<Tag>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<Ingredient> Ingredients { get; set; }

        public List<Step> Steps { get; set; }

        public Category Category { get; set; }

        public List<Tag> Tags { get; set; }
    }
}
