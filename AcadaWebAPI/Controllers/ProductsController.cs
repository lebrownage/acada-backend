using Acada.Business.DTOs.Models;
using Acada.Business.Services;
using Acada.Domain.Interfaces;
using Acada.WebAPI.HelpersClasses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Acada.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _product;
        private readonly ILogger<ProductsController> _logger;
        public ProductsController(IProductService product, ILogger<ProductsController> logger)
        {
            _product = product;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<List<ProductDto>> GetProducts()
        {
            //get all the products
            return _product.GetProducts();
        }

        [HttpGet("{id}")]
        public ActionResult<ProductDto?> GetProductById(long id)
        {
            //if id is 0 considered its null so return bad request
            if (id == 0)
            {
                return BadRequest("Missing Parameter ID");
            }

            return _product.GetProductById(id);
        }

        [HttpPost]
        public IActionResult AddProduct(ProductDto data)
        {

            //check if data is valid
            if (Helper.IsInvalidProduct(data))
            {
                return BadRequest("Missing or Invalid Values");
            }
            //add the product
            ProductDto newProduct = _product.AddProduct(data);
            //if product is null return Error
            if (newProduct == null)
            {
                _logger.Log(LogLevel.Error, "Error in Adding Product");
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry something went wrong");
            }

            return Ok(newProduct);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(long id, [FromBody]ProductDto data)
        {
            //check if data is valid
            if (Helper.IsInvalidProduct(data)) 
            {
                return BadRequest("Missing or Invalid Values");
            }

            ProductDto getProduct = _product.GetProductById(id);
            if (getProduct == null)
            {
                return BadRequest("Product does not exist");
            }

            //update the prodcut
            bool isUpdated = _product.UpdateProduct(data);

            //check if its updated
            if(!isUpdated) 
            { 
                _logger.Log(LogLevel.Error, "Error in Updating Product");
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry something went wrong");
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(long id)
        {
            //if id is 0 considered its null so return bad request
            if(id == 0)
            {
                return BadRequest("Missing Parameter ID");
            }

            bool isDeleted = _product.DeleteProduct(id);
            if (!isDeleted)
            {
                _logger.Log(LogLevel.Error, "Error in Deleting Product");
                return StatusCode(StatusCodes.Status500InternalServerError, "Sorry something went wrong");
            }

            return Ok();
        }
    }
}
