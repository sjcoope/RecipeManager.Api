using SJCNet.RecipeManager.Model;
using SJCNet.RecipeManager.Model.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Samples
{
    public abstract class Sample<T> where T : class, IEntity
    {
        public Sample(SampleContext context)
        {
            this.Data = new List<T>();
            this.Context = context;

            InitializeData();
        }

        protected abstract void InitializeData();

        protected List<T> Data { get; private set; }

        protected SampleContext Context { get; private set; }

        public IQueryable<T> Entities
        {
            get
            {
                return this.Data.AsQueryable();
            }
        }

        public T GetRandomEntity()
        {
            var index = new Random().Next((this.Data.Count() - 1));
            return this.Data[index];
        }
    }
}
