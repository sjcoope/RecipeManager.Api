using SJCNet.RecipeManager.Data.Uow.Contract;
using SJCNet.RecipeManager.Model;
using System.Linq;
using System.Web.Http;

namespace SJCNet.RecipeManager.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        private readonly IRecipeManagerUow _uow = null;

        public CategoryController(IRecipeManagerUow uow)
        {
            _uow = uow;
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            return Ok(_uow.Categories.GetById(id));
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(_uow.Categories.GetAll().ToList());
        }

        [HttpPost]
        public IHttpActionResult Post(Category category)
        {
            _uow.Categories.Add(category);
            _uow.Commit();

            // Return the new object
            return Ok(category);
        }

        [HttpPut]
        public IHttpActionResult Put(int id, Category category)
        {
            _uow.Categories.Update(category);
            _uow.Commit();
            return Ok(category);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            return Ok(_uow.Categories.Delete(id));
        }
    }
}
