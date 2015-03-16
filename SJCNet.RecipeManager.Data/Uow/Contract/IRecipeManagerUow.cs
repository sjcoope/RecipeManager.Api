using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJCNet.RecipeManager.Data.Repository.Contract;
using SJCNet.RecipeManager.Model;

namespace SJCNet.RecipeManager.Data.Uow.Contract
{
    public interface IRecipeManagerUow : IDisposable
    {
        void Commit();
        IRepository<Category> Categories { get; }
        IRepository<Ingredient> Ingredients { get; }
        IRepository<Measurement> Measurements { get; }
        IRepository<Product> Products { get; }
        IRepository<Recipe> Recipes { get; }
        IRepository<Step> Steps { get; }
        IRepository<Tag> Tags { get; }
        IRepository<User> Users { get; }
    }
}
