using SJCNet.RecipeManager.Data.Uow;
using SJCNet.RecipeManager.Data.Uow.Contract;
using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SJCNet.RecipeManager.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private IRecipeManagerUow _uow = null;

        public CategoryController()
        {
            _uow = new RecipeManagerUow();
        }

        [HttpGet]
        public Category Get(int id)
        {
            return _uow.Categories.GetById(id);
        }

        [HttpGet]
        public List<Category> Get()
        {
            return _uow.Categories.GetAll().ToList();
        }

        [HttpPost]
        public void Post(Category category)
        {
            _uow.Categories.Add(category);
            _uow.Commit();
        }

        [HttpPut]
        public void Put(int id, Category category)
        {
            var original = _uow.Categories.GetById(id);
            if (original.Name != category.Name)
            {
                original.Name = category.Name;
            }

            _uow.Commit();
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _uow.Categories.Delete(id);
            _uow.Commit();
        }
    }
}
