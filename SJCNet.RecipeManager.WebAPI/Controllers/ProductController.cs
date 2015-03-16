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
    public class ProductController : ApiController
    {
       private IRecipeManagerUow _uow = null;

       public ProductController(IRecipeManagerUow uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var product = _uow.Products.GetById(id);
            if(product == null)
            {
                return NotFound();
            }
            return Ok(product);            
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_uow.Products.GetAll().ToList());
        }

        [HttpPost]
        public IHttpActionResult Post(Product product)
        {
            _uow.Products.Add(product);
            _uow.Commit();

            return Ok(product);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Product product)
        {
            _uow.Products.Update(product);
            _uow.Commit();
            return Ok(product);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_uow.Products.Delete(id));
        }
    }
}