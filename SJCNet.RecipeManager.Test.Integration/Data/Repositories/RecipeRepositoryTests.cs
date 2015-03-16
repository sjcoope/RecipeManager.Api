using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SJCNet.RecipeManager.Data.Uow.Contract;
using SJCNet.RecipeManager.Data.Uow;
using System.Linq;
using SJCNet.RecipeManager.Data;
using SJCNet.RecipeManager.Data.Repository.Contract;
using SJCNet.RecipeManager.Model;
using SJCNet.RecipeManager.Data.Repository;
using System.Data.Entity;
using SJCNet.RecipeManager.Test.Samples;
using SJCNet.RecipeManager.Test.Common.Database;

namespace SJCNet.RecipeManager.Test.Integration.Data.Repositories.Recipes
{
    [TestClass]
    [DeploymentItem(@"Artifacts", @"Artifacts")]
    public class RecipeRepositoryTests
    {
        private RecipeManagerDbContext _context;

        #region Initialize and Cleanup

        [TestInitialize]
        public void TestInitialize()
        {
            // Arrange - Initialize the DbContext (set to recreate and initialize the database for each test).
            _context = new RecipeManagerDbContext();
            Database.SetInitializer<RecipeManagerDbContext>(new TestDatabaseInitializer());
            _context.Database.Initialize(true);
        }

        [TestCleanup]
        public void TestCleanup()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        #endregion

        #region Helper Methods

        private void VerifyEntity(Recipe actual, int expectedId = 0)
        {
            // Assert - Check the entity
            Assert.IsNotNull(actual);
            if (expectedId != 0) { Assert.AreEqual(expectedId, actual.Id); }
            else { Assert.IsTrue(actual.Id > 0); }
            Assert.IsFalse(String.IsNullOrEmpty(actual.Name));
            Assert.IsFalse(String.IsNullOrEmpty(actual.Description));
            Assert.IsTrue(actual.Ingredients.Count() > 0);
            Assert.IsTrue(actual.Steps.Count() > 0);
            Assert.IsNotNull(actual.Category);
            Assert.IsTrue(actual.Tags.Count() > 0);

            // Assert - Check the first ingredient
            var ingredient = actual.Ingredients.First();
            Assert.IsNotNull(ingredient);
            Assert.IsTrue(ingredient.Id > 0);
            Assert.IsTrue(ingredient.Unit > 0);
            Assert.IsTrue(ingredient.SortOrder > 0);

            // Assert - Check the ingredients measurement
            Assert.IsNotNull(ingredient.Measurement);
            Assert.IsTrue(ingredient.Measurement.Id > 0);
            Assert.IsFalse(String.IsNullOrEmpty(ingredient.Measurement.Name));

            // Assert - Check the ingredients product
            Assert.IsNotNull(ingredient.Product);
            Assert.IsTrue(ingredient.Product.Id > 0);
            Assert.IsFalse(String.IsNullOrEmpty(ingredient.Product.Name));

            // Assert - Check the first Step
            var step = actual.Steps.First();
            Assert.IsNotNull(step);
            Assert.IsTrue(step.Id > 0);
            Assert.IsFalse(String.IsNullOrEmpty(step.Description));
            Assert.IsTrue(step.SortOrder > 0);

            // Assert - Check the Category
            Assert.IsNotNull(actual.Category);
            Assert.IsTrue(actual.Category.Id > 0);
            Assert.IsFalse(String.IsNullOrEmpty(actual.Category.Name));

            // Assert - Check the first Tag
            var tag = actual.Tags.First();
            Assert.IsNotNull(tag);
            Assert.IsTrue(tag.Id > 0);
            Assert.IsFalse(String.IsNullOrEmpty(tag.Name));
        }

        private void CompareEntities(Recipe expected, Recipe actual)
        {
            // Assert - Check the entity
            Assert.AreEqual(expected.Id, actual.Id);
            Assert.AreEqual(expected.Name, actual.Name);
            Assert.AreEqual(expected.Description, actual.Description);
            Assert.AreEqual(expected.Steps.Count(), actual.Steps.Count());
            Assert.AreEqual(expected.Ingredients.Count(), actual.Ingredients.Count());
            Assert.AreEqual(expected.Tags.Count(), actual.Tags.Count());

            // Assert - Check the ingredients (matches on unit)
            foreach(var expectedIngredient in expected.Ingredients) {
                var actualIngredient = actual.Ingredients.SingleOrDefault(i => i.Unit == expectedIngredient.Unit);
                if (actualIngredient == null) { Assert.Fail("Cannot match ingredient"); }

                Assert.AreEqual(expectedIngredient.Unit, actualIngredient.Unit);
                Assert.AreEqual(expectedIngredient.SortOrder, actualIngredient.SortOrder);

                Assert.AreEqual(expectedIngredient.Measurement.Id, actualIngredient.Measurement.Id);
                Assert.AreEqual(expectedIngredient.Measurement.Name, actualIngredient.Measurement.Name);

                Assert.AreEqual(expectedIngredient.Product.Id, actualIngredient.Product.Id);
                Assert.AreEqual(expectedIngredient.Product.Name, actualIngredient.Product.Name);
            }

            // Assert - Check the steps (matches on description)
            foreach(var expectedStep in expected.Steps)
            {
                var actualStep = actual.Steps.SingleOrDefault(i => i.Description == expectedStep.Description);
                if (actualStep == null) { Assert.Fail("Cannot match step"); }

                Assert.AreEqual(expectedStep.Description, actualStep.Description);
                Assert.AreEqual(expectedStep.SortOrder, actualStep.SortOrder);
            }

            // Assert - Check the category
            Assert.AreEqual(expected.Category.Name, actual.Category.Name);

            // Assert - Check the tags (matches on name)
            foreach(var expectedTag in expected.Tags)
            {
                var actualTag = actual.Tags.SingleOrDefault(i => i.Name == expectedTag.Name);
                if (actualTag == null) { Assert.Fail("Cannot match tag"); }

                Assert.AreEqual(expectedTag.Name, actualTag.Name);
            }
        }

        #endregion

        #region Test Methods

        [TestMethod]
        public void GetById_Test()
        {
            // Arrange - Create the repository
            var repository = new RecipeRepository(_context);
            
            // Arrange - Setup expectations
            var expectedId = 1;

            // Act - Make the repository call
            repository.FullEagerLoad();
            var actual = repository.GetById(expectedId);

            // Assert - Verify the entity
            VerifyEntity(actual, expectedId);
        }

        [TestMethod]
        public void GetAll_Test()
        {
            // Arrange - Create the repository
            var repository = new RecipeRepository(_context);

            // Act - Set-up the repository call
            repository.FullEagerLoad();
            var actualList = repository.GetAll();

            // Assert - Check the result
            Assert.IsNotNull(actualList);
            Assert.IsTrue(actualList.Count() > 0);

            // Assert - Check the list count against the sample data.
            var sampleData = new SampleContext();
            Assert.AreEqual(actualList.Count(), sampleData.Recipes.Entities.Count());

            // Assert - Test the first recipe
            var recipe = actualList.First();
            VerifyEntity(recipe);

        }

        [TestMethod]
        public void AddSingle_Test()
        {
            // Arrange - Create the repository
            var repository = new RecipeRepository(_context);

            // Arrange - Create the new recipe
            var sampleData = new SampleContext();
            var expected = new Recipe { Name = "New Recipe One", Description = "Test New Description One", Category = (Category)sampleData.Categories.GetRandomEntity() };
            expected.Steps.Add(new Step { Description = "New Step One", SortOrder = 1 });
            expected.Steps.Add(new Step { Description = "New Step Two", SortOrder = 2 });
            expected.Ingredients.Add(new Ingredient { Unit = 1, Measurement = (Measurement)sampleData.Measurements.GetRandomEntity(), Product = (Product)sampleData.Products.GetRandomEntity(), SortOrder = 1 });
            expected.Ingredients.Add(new Ingredient { Unit = 2, Measurement = (Measurement)sampleData.Measurements.GetRandomEntity(), Product = (Product)sampleData.Products.GetRandomEntity(), SortOrder = 2 });

            // Arrange - Set the expected count
            var expectedRecipeCount = repository.GetAll().Count() + 1;

            // Act - Perform the repository call
            repository.Add(expected);
            _context.SaveChanges();

            // Assert - Check for the addition
            Assert.AreEqual(expectedRecipeCount, repository.GetAll().Count());
            
            // Verify the entity (gets by name as this should be unique in this test)
            repository.FullEagerLoad();
            var actual = repository.GetAll().SingleOrDefault(i => i.Name == expected.Name);
            Assert.IsNotNull(actual);
            CompareEntities(expected, actual);
        }

        [TestMethod]
        public void AddMultiple_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateSingle_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void UpdateMultiple_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteSingleById_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteSingleByEntity_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void DeleteMultiple_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void EagerLoad_Test()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public void FullEagerLoad_Test()
        {
            Assert.IsTrue(true);
        }

        #endregion
    }
}
