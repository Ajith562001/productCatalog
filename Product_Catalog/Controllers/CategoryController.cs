using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product_Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<Entity.Category> GetAllCategories()
        {
            Entity.CatalogContext entity = new Entity.CatalogContext();
            var data = (from a in entity.Categories
                     select a).ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Add")]
        public ActionResult<Entity.Category> AddCategories([FromBody] Entity.Category entity)
        {
            Entity.CatalogContext context = new Entity.CatalogContext();

            context.Categories.Add(entity);
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id:int}")]
        public ActionResult Delete(int id)
        {
            if(id == 1) 
            {
                return BadRequest();
            }

            Entity.CatalogContext context = new Entity.CatalogContext();

            var data = context.Categories.Find(id);

            if(data == null)
            {
                return NotFound();
            }

            context.Categories.Remove(data);
            context.SaveChanges();
            return Ok();
        }


    }
}