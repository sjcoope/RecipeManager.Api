using SJCNet.RecipeManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SJCNet.RecipeManager.Data.Uow.Contract;

namespace SJCNet.RecipeManager.WebAPI.Controllers
{
    /* NOTES - Remote
     * - Use nouns
     * - Model Validation
     * - Do I need to send back DTOs?
     * */

    public class CategoriesController : ApiController
    {
        private readonly IRecipeManagerUow _uow = null;

        public CategoriesController(IRecipeManagerUow uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            try
            {
                var categories = _uow.Categories.GetAll();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                // TODO: Logging
                return InternalServerError();
            }
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            try
            {
                var category = _uow.Categories.GetById(id);
                if (category == null)
                {
                    return NotFound();
                }
                else
                {
                    return Ok(category);
                }
            }
            catch (Exception ex)
            {
                // TODO: Logging
                return InternalServerError();
            }
        }

        [HttpPost]
        public IHttpActionResult Post([FromBody] Category entity)
        {
            try
            {
                if (entity == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                _uow.Categories.Add(entity);
                _uow.Commit();

                return Created(Request.RequestUri + "/" + entity.Id, entity);
            }
            catch (Exception)
            {
                // TODO: Logging
                return InternalServerError();
            }
        }

        [HttpPut]
        public IHttpActionResult Put(int id, [FromBody] Category entity)
        {
            try
            {
                if (entity == null || !ModelState.IsValid)
                {
                    return BadRequest();
                }

                var entityToUpdate = _uow.Categories.GetById(id);
                if (entityToUpdate == null)
                {
                    return NotFound();
                }

                entityToUpdate.Name = entity.Name;
                _uow.Categories.Update(entityToUpdate);
                _uow.Commit();

                return Ok(entityToUpdate);
            }
            catch (Exception)
            {
                // TODO: Logging
                return InternalServerError();
            }
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var result = _uow.Categories.Delete(id);
                if (result)
                {
                    
                }
            }
            catch (Exception ex)
            {
                // TODO: Logging
                return InternalServerError();
            }
        }

    }
}
