using SJCNet.RecipeManager.Data.Repository.Contract;
using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SJCNet.RecipeManager.Data.Repository;
using SJCNet.RecipeManager.Data.Uow.Contract;

namespace SJCNet.RecipeManager.Data.Uow
{
    public class RecipeManagerUow : IRecipeManagerUow
    {
        #region Variables

        IRepository<Category> _categories = null;
        IRepository<Ingredient> _ingredients = null;
        IRepository<Measurement> _measurements = null;
        IRepository<Recipe> _recipes = null;
        IRepository<Step> _steps = null;
        IRepository<Tag> _tags = null;
        IRepository<User> _users = null;

        #endregion

        #region Constructors

        public RecipeManagerUow()
        {
            Initialize();
        }

        public RecipeManagerUow(RecipeManagerDbContext context)
        {
            Initialize(context);
        }

        #endregion

        #region Public Methods

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        #endregion

        #region Public Properties

        public IRepository<Category> Categories
        {
            get { return _categories ?? (_categories = new EFRepository<Category>(this.Context)); }
        }

        public IRepository<Ingredient> Ingredients
        {
            get { return _ingredients ?? (_ingredients = new EFRepository<Ingredient>(this.Context)); }
        }

        public IRepository<Measurement> Measurements
        {
            get { return _measurements ?? (_measurements = new EFRepository<Measurement>(this.Context)); }
        }

        public IRepository<Recipe> Recipes
        {
            get { return _recipes ?? (_recipes = new RecipeRepository(this.Context)); }
        }

        public IRepository<Step> Steps
        {
            get { return _steps ?? (_steps = new EFRepository<Step>(this.Context)); }
        }

        public IRepository<Tag> Tags
        {
            get { return _tags ?? (_tags = new EFRepository<Tag>(this.Context)); }
        }

        public IRepository<User> Users
        {
            get { return _users ?? (_users = new EFRepository<User>(this.Context)); }
        }

        #endregion

        #region Private Methods

        private void Initialize(RecipeManagerDbContext context = null)
        {
            Context = context == null ? new RecipeManagerDbContext() : context;
        }
        
        #endregion

        #region Private Properties

        private DbContext Context { get; set; }

        #endregion

        #region IDisposable Implementation

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // Clear managed resources
                if (this.Context != null)
                {
                    this.Context.Dispose();
                    this.Context = null;
                }
            }
        }

        #endregion
    }
}
