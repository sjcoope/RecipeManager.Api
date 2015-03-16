using FluentValidation;
using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SJCNet.RecipeManager.WebAPI.Validators
{
    public class RecipeValidator : AbstractValidator<Recipe>
    {
        public RecipeValidator()
        {
            // TODO: Finalise validation.
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Description).NotEmpty();
            RuleFor(x => x.Category).NotNull();
        }
    }
}