using SJCNet.RecipeManager.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Model
{
    public class Step : IEntity
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public int SortOrder { get; set; }
    }
}
