using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product_Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Sub_CategoryController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<Entity.SubCategory> GetAllSubCategories()
        {
            Entity.CatalogContext entity = new Entity.CatalogContext();
            var data = (from a in entity.SubCategories
                        select a).ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("GetByNO")]
        public ActionResult<Entity.SubCategory> GetSubCategoryId(int No)
        {
            Entity.CatalogContext entity = new Entity.CatalogContext();
            var data = (from a in entity.SubCategories
                        where (a.SubCategoryNo == No)
                        select a).ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Add")]
        public ActionResult<Entity.SubCategory> AddSubCategories([FromBody] Entity.SubCategory entity)
        {
            Entity.CatalogContext context = new Entity.CatalogContext();

            context.SubCategories.Add(entity);
            context.SaveChanges();
            return Ok();
        }
        [HttpPut("UpdateSubCategory")]
        public ActionResult<Entity.SubCategory> UpdateSubCategory([FromBody] Entity.SubCategory entity)
        {
            Entity.CatalogContext context = new Entity.CatalogContext();
            if (entity == null)
            {
                return BadRequest();
            }

            context.SubCategories.Update(entity);
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{No:int}")]
        public ActionResult Delete(int No)
        {
            if (No == 0)
            {
                return BadRequest();
            }

            Entity.CatalogContext context = new Entity.CatalogContext();

            var data = context.SubCategories.Find(No);

            if (data == null)
            {
                return NotFound();
            }

            context.SubCategories.Remove(data);
            context.SaveChanges();
            return Ok();
        }


    }
}
