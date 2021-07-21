using AutoMapper;
using Core.Domain.Entities;
using Core.DomainServices.Interfaces;
using Core.DomainServices.Specifications;
using e_commerce.DTOs;
using e_commerce.Errors;
using Infrastructure.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace e_commerce.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo,
            IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepo = productTypeRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts(string sort, int? brandId, int? typeId)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(sort, brandId, typeId);
            var products = await this.productsRepo.ListAsync(spec);

            return Ok(mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(products));
        }
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse),StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            var product = await this.productsRepo.GetEntityWithSpec(spec);

            if (product == null) return NotFound(new ApiResponse(404));

            return mapper.Map<Product, ProductToReturnDto>(product);
        }
        [HttpGet("brands")]
        public async Task<ActionResult<List<ProductBrand>>> GetProductBrands()
        {
            var products = await this.productBrandRepo.GetAllAsync();
            return Ok(products);
        }
        [HttpGet("types")]
        public async Task<ActionResult<List<ProductType>>> GetProductTypes()
        {
            var products = await this.productTypeRepo.GetAllAsync();
            return Ok(products);
        }
        
    }
}
