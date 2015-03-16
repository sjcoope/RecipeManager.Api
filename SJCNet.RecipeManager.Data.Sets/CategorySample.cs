using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Samples
{
    public class CategorySample : Sample<Category>
    {
        public CategorySample(SampleContext context) : base(context)
        {}

        protected override void InitializeData()
        {
            var categoryBreakfast = new Category { Name = "Breakfast" };
            base.Data.Add(categoryBreakfast);

            var categoryLunch = new Category { Name = "Lunch" };
            base.Data.Add(categoryLunch);

            var categoryDinner = new Category { Name = "Dinner" };
            base.Data.Add(categoryDinner);

            var categorySnack = new Category { Name = "Snacks" };
            base.Data.Add(categorySnack);
        }
    }
}
