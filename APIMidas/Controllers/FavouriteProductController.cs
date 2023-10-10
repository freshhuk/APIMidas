using Microsoft.AspNetCore.Mvc;
using InfrastructureMidas.Interfaces;
using DomainMidas.Entities;
using DomainMidas.Models;

namespace APIMidas.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FavouriteProductController : Controller
    {
        private readonly IDataContext<Product> _dataContext;
        public FavouriteProductController(IDataContext<Product> dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet("GetAllProduct")]
        public IActionResult GetAllProduct()
        {
            var products = _dataContext.GetAll();
            return Ok(products);
        }

        [HttpPost("AddProductToFavourite")]
        public async Task<IActionResult> AddProductToFavourite(Product product)
        {
            if(product != null)
            {
                await _dataContext.AddAsync(product);
                await _dataContext.SaveChangesAsync();
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpDelete("DeleteFavouriteProduct")]
        public async Task<IActionResult> DeleteFavouriteProduct(int Id)
        {
            var product = _dataContext.Get(Id);
            if(product != null)
            {
                _dataContext.Delete(Id);
                await _dataContext.SaveChangesAsync();
                return Ok();
            }
            else 
            { 
                return BadRequest(); 
            }
        }
        [HttpPut("UpdateFavouriteProduct")]
        public async Task<IActionResult> UpdateFavouriteProduct(UpdateProductModel product)
        {
            var model = _dataContext.Get(product.Id);
            if (model != null)
            {
                
                if (!string.IsNullOrEmpty(product.Name) && !string.IsNullOrEmpty(product.Description))
                {
                    model.Id = product.Id;
                    model.Name = product.Name;
                    model.Description = product.Description;
                    model.Price = product.Price;

                    await _dataContext.SaveChangesAsync();
       
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            else
            {  
                return BadRequest();
            }
        }


    }
}
