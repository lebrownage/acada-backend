using Acada.Business.DTOs.Models;
using Acada.Domain.Entities;

namespace Acada.Business.Services
{
    public interface  IProductService
    {
        List<ProductDto> GetProducts();
        ProductDto? GetProductById(long id);
        ProductDto? AddProduct(ProductDto product);
        bool UpdateProduct(ProductDto product);
        bool DeleteProduct(long id);
    }
}
