﻿using SJCNet.RecipeManager.Data.Uow;
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
    public class RecipeController : ApiController
    {
        private IRecipeManagerUow _uow = null;

        public RecipeController(IRecipeManagerUow uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var recipe = _uow.Recipes.GetById(id);
            if (recipe == null)
            {
                return NotFound();
            }
            return Ok(recipe);
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            _uow.Recipes.FullEagerLoad();
            return Ok(_uow.Recipes.GetAll().ToList());
        }

        [HttpPost]
        public IHttpActionResult Post(Recipe recipe)
        {
            _uow.Recipes.Add(recipe);
            _uow.Commit();

            // Return the new recipe
            return Ok(recipe);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Recipe recipe)
        {
            _uow.Recipes.Update(recipe);
            _uow.Commit();
            return Ok(recipe);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_uow.Recipes.Delete(id));
        }
    }
}
