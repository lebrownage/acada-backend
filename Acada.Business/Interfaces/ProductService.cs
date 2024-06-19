using Acada.Business.DTOs.Models;
using Acada.Business.Services;
using Acada.Domain.Entities;
using Acada.Domain.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Acada.Business.Interfaces
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _product;
        private readonly IMapper _map;
        public ProductService(IProductRepository product, IMapper map) 
        { 
            _product = product;
            _map = map;
        }

        public ProductDto? AddProduct(ProductDto product)
        {
            Product productEntity = _map.Map<Product>(product);
            return _map.Map<ProductDto>(_product.AddProduct(productEntity));
        }

        public bool DeleteProduct(long id)
        {
            return _product.DeleteProduct(id);
        }

        public ProductDto? GetProductById(long id)
        {
            return _map.Map<ProductDto>(_product.GetProductById(id));
        }

        public List<ProductDto> GetProducts()
        {
            return _map.Map<List<ProductDto>>(_product.GetProducts());
        }

        public bool UpdateProduct(ProductDto product)
        {
            return _product.UpdateProduct(_map.Map<Product>(product));
        }
    }
}
