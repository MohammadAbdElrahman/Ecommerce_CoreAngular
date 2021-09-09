using Core.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Interfaces;
using Core.Specifications;
using API.DTO;
using System.Linq;
using AutoMapper;
using API.Errors;
using Microsoft.AspNetCore.Http;

namespace API.Controllers
{
    public class ProductsController : BaseApiController
    {

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _brandRepository;
        private readonly IGenericRepository<ProductType> _typeRepository;
        private readonly IMapper _mapper;
        public ProductsController(IGenericRepository<Product> productRepository
            , IGenericRepository<ProductBrand> brandRepository
            , IGenericRepository<ProductType> typeRepository,IMapper mapper)
        {
            _productRepository = productRepository;
            _brandRepository = brandRepository;
            _typeRepository = typeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductDto>>> GetProducts()
        {
            var specification = new ProductsWithTypes_BrandsSpecification();
            var products = await _productRepository.GetListWithSpecificationAsync(specification);
            return Ok(_mapper
                .Map<IReadOnlyList<Product>,IReadOnlyList<ProductDto>>(products));
        
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductDto>>GetProduct(int id) 
        {
            var specification = new ProductsWithTypes_BrandsSpecification(id);

            var product =await _productRepository.GetOneBySpecificationAsync(specification);
            if (product==null)
            {
                return NotFound(new ApiResponse(404));
            }
            return _mapper.Map<Product,ProductDto>(product);
  
        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await  _brandRepository.GetAllAsync());
        }
        
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await  _typeRepository.GetAllAsync());
        }
    }
}
