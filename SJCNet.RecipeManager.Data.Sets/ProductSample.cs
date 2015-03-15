using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SJCNet.RecipeManager.Test.Samples
{
    public class ProductSample : Sample<Product>
    {
        public ProductSample(SampleContext context) : base(context)
        {}

        protected override void InitializeData()
        {
            var productFlour = new Product { Name = "Plain Flour" };
            base.Data.Add(productFlour);

            var productEgg = new Product { Name = "Egg" };
            base.Data.Add(productEgg);

            var productSugar = new Product { Name = "Sugar" };
            base.Data.Add(productSugar);

            var productButter = new Product { Name = "Butter" };
            base.Data.Add(productButter);

            var productMilk = new Product { Name = "Milk" };
            base.Data.Add(productMilk);
        }
    }
}
