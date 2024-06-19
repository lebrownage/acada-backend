using Acada.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acada.Domain.Interfaces
{
    public interface IProductRepository
    {
        List<Product> GetProducts();
        Product? GetProductById(long id);
        Product? AddProduct(Product product);
        bool UpdateProduct(Product product);
        bool DeleteProduct(long id);
    }
}
