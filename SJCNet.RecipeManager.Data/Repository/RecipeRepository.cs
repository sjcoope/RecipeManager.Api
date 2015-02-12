using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Data.Repository
{
    public class RecipeRepository : EFRepository<Recipe>
    {
        public RecipeRepository(DbContext context) : base(context)
        {}

        public override void FullEagerLoad()
        {
            EagerLoad(
                i => i.Category,
                i => i.Steps,
                i => i.Ingredients,
                i => i.Ingredients.Select(x => x.Product),
                i => i.Ingredients.Select(x => x.Measurement)
            );
        }
    }
}
