using Acada.Domain.Entities;
using Acada.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acada.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        
        private readonly ILogger<ProductRepository> _logger;
        private readonly DataContext _context;
        public ProductRepository(DataContext context, ILogger<ProductRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Product? AddProduct(Product product)
        {
            try
            {
                //add the product and return the newly added product with generated ID
                Product newProduct = _context.Product.Add(product).Entity;
                _ = _context.SaveChanges();
                return newProduct;
            }
            catch (Exception ex)
            {
                //log error
                _logger.LogError(ex, "Error on Adding Product");
                return null;
            }
        }

        public bool DeleteProduct(long id)
        {
            try
            {
                Product getProduct = GetProductById(id);
                //check if the product exist
                if(getProduct == null)
                {
                    return false;
                }
                _ = _context.Product.Remove(getProduct);
                _ = _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on Deleting Product");
                return false;
            }
        }

        public Product? GetProductById(long id)
        {
            try
            {
                Product? getProduct = _context.Product.Find(id);
                return _context.Product.Find(id);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on Getting Product by ID");
                return null;
            }
        }

        public List<Product> GetProducts()
        {
            try
            {
                return _context.Product.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error on Getting All Products");
                return new List<Product>();
            }
        }

        public bool UpdateProduct(Product product)
        {
            try
            {
                //detach to disable tracking
                _context.Entry(product).State = EntityState.Detached;
                //create untracked and 
                Product trackedProduct = _context.Product.FirstOrDefault(p => p.Id == product.Id);
                if (trackedProduct != null)
                {
                    _context.Entry(trackedProduct).CurrentValues.SetValues(product);
                }
                _context.SaveChanges();

                return true;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "Error on Updating Product");
                return false;
            }
        }
    }
}
