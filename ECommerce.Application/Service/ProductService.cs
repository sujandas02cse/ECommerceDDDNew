using AutoMapper;
using ECommerce.Application.DTOs;
using ECommerce.Domain.Entities;
using ECommerce.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECommerce.Application.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductDTO?> AddProductAsync(CreateProductDTO productDTO)
        {
            var product = new Product(productDTO.Name, productDTO.price, productDTO.Description,productDTO.StockQuantity);

            var createdProduct = await _productRepository.AddAsync(product);
            return _mapper.Map<ProductDTO>(createdProduct);
        }

        public async Task<ProductDTO?> GetProductByIdAsync(int id)
        {
            var product=await _productRepository.GetByIdAsync(id);
            return product ==null? null :_mapper.Map<ProductDTO>(product);

        }

        public async Task<IEnumerable<ProductDTO>> GetProductsAsync()
        {
           var products=await _productRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ProductDTO>>(products);
        }
    }
}
