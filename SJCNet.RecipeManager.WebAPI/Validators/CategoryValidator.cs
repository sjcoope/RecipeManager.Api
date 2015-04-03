using FluentValidation;
using SJCNet.RecipeManager.Model;

namespace SJCNet.RecipeManager.WebAPI.Validators
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
        }
    }
}