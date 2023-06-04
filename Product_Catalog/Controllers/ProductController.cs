using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Product_Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        [HttpGet("GetAll")]
        public ActionResult<Entity.Product> GetAllProduct()
        {
            Entity.CatalogContext entity = new Entity.CatalogContext();
            var data = (from a in entity.Products
                        select a).ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }
        [HttpGet("GetByNO")]
        public ActionResult<Entity.Product> GetByProductNo(int No)
        {
            Entity.CatalogContext entity = new Entity.CatalogContext();
            var data = (from a in entity.Products
                        where (a.ProductNo == No)
                        select a).ToList();

            if (data == null)
            {
                return NotFound();
            }
            return Ok(data);
        }

        [HttpPost("Add")]
        public ActionResult<Entity.Product> AddProduct([FromBody] Entity.Product entity)
        {
            Entity.CatalogContext context = new Entity.CatalogContext();
            if(entity == null)
            {
                return BadRequest();
            }

            context.Products.Add(entity);
            context.SaveChanges();
            return Ok();
        }
        [HttpPut("Updateproduct")]
        public ActionResult<Entity.Product> UpdateProduct([FromBody] Entity.Product entity)
        {
            Entity.CatalogContext context = new Entity.CatalogContext();
            if (entity == null)
            {
                return BadRequest();
            }

            context.Products.Update(entity);
            context.SaveChanges();
            return Ok();
        }


        [HttpDelete("{No:int}")]
        public ActionResult<Entity.Product> Delete(int No)
        {
            if (No == 0)
            {
                return BadRequest();
            }

            Entity.CatalogContext context = new Entity.CatalogContext();

            var data = context.Products.Find(No);

            if (data == null)
            {
                return NotFound();
            }

            context.Products.Remove(data);
            context.SaveChanges();
            return Ok();
        }

    }
}
