using SJCNet.RecipeManager.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Model
{
    public class Ingredient : IEntity
    {
        public int Id { get; set; }

        public Product Product { get; set; }

        public int Unit { get; set; }

        public Measurement Measurement { get; set; }

        public int SortOrder { get; set; }
    }
}
