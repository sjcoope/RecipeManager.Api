using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SJCNet.RecipeManager.Data.Uow.Contract;
using SJCNet.RecipeManager.Data.Uow;
using System.Linq;

namespace SJCNet.RecipeManager.Test.Unit
{
    [TestClass]
    public class RecipeRepositoryTests
    {
        private IRecipeManagerUow _uow1 = null;
        private IRecipeManagerUow _uow2 = null;

        #region Initialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            _uow1 = new RecipeManagerUow();
            _uow2 = new RecipeManagerUow();
        }
        
        [TestCleanup]
        public void TestCleanup()
        {
            if(_uow1 != null)
            {
                _uow1.Dispose();
                _uow1 = null;
            }

            if(_uow2 != null)
            {
                _uow2.Dispose();
                _uow2 = null;
            }
        }

        #endregion

        [TestMethod]
        public void SamplePassingTest()
        {
            Assert.IsTrue(true);
        }

        // TODO: Replace DB calls with mocks.
        //[TestMethod]
        //public void GetById_Test()
        //{
        //    // Arrange
        //    var expectedId = 1;

        //    // Act
        //    _uow1.Recipes.FullEagerLoad();
        //    var actual = _uow1.Recipes.GetById(expectedId);

        //    // Assert
        //    Assert.IsNotNull(actual);
        //    Assert.IsNotNull(actual.Id);
        //    Assert.IsNotNull(actual.Name);
        //    Assert.IsNotNull(actual.Steps);
        //    Assert.IsNotNull(actual.Ingredients);
        //    Assert.IsNotNull(actual.Description);
        //    Assert.IsNotNull(actual.Category);

        //    Assert.AreEqual(actual.Id, expectedId);
        //}

        //[TestMethod]
        //public void GetAll_Test()
        //{
        //    // Arrange
        //    var expectedCount = 5;

        //    // Act
        //    var actualRecipes = _uow1.Recipes.GetAll().ToList();
            
        //    // Assert
        //    Assert.IsNotNull(actualRecipes);
        //    Assert.AreEqual(actualRecipes.Count, expectedCount);
        //}
    }
}
