using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SJCNet.RecipeManager.Data.Repository.Contract;
using SJCNet.RecipeManager.Model;
using SJCNet.RecipeManager.Test.Samples;
using SJCNet.RecipeManager.WebAPI.Controllers;
using SJCNet.RecipeManager.Data.Uow.Contract;
using System.Web.Http.Results;

namespace SJCNet.RecipeManager.Test.Unit.Controllers
{
    [TestClass]
    public class RecipeControllerTests
    {
        [TestMethod]
        public void GetReturnsValidRecipeWithSameId()
        {
            // Arrange
            var mockRepository = new Mock<IRepository<Recipe>>();
            var sampleData = new SampleContext();
            var expected = sampleData.Recipes.Entities.First();
            mockRepository.Setup(m => m.GetById(1)).Returns(expected);
            var mockUow = new Mock<IRecipeManagerUow>();
            mockUow.Setup(m => m.Recipes).Returns(mockRepository.Object);

            // Arrange
            var controller = new RecipeController(mockUow.Object);

            // Act
            var actionResult = controller.Get(1);
            var contentResult = actionResult as OkNegotiatedContentResult<Recipe>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(1, contentResult.Content.Id);
        }
    }
}
