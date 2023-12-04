using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreWebAPIApplication.CustomActionFilters;
using StoreWebAPIApplication.Data;
using StoreWebAPIApplication.DataTransferObjects;
using StoreWebAPIApplication.DomainModels;
using StoreWebAPIApplication.Repositories;
using System.Runtime.CompilerServices;

namespace StoreWebAPIApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoresController:ControllerBase
    {
        private readonly ProductStoreDbContext dbProductContext;
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public StoresController(ProductStoreDbContext dbProductContext, IProductRepository productRepository, IMapper mapper)
        {
            this.dbProductContext = dbProductContext;
            this.productRepository = productRepository;
            this.mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetAllProductStore([FromQuery] string? filterOn, [FromQuery] string?filterQuery)
        {
            //Get Data From Domain Model
            var StoreDomain = await productRepository.GetAllProductStoreAsync(filterOn,filterQuery);
            var ProductsDomain = await productRepository.GetAllAsync();
            var query = from store in StoreDomain
                        join product in ProductsDomain on store.ProductId equals product.ProductId
                        select new ProductStoreDto
                        {
                            StoreName = store.StoreName,
                            ProductName = product.ProductName,
                            ProductPrice = product.ProductPrice
                        };
            //Convert Domain Model and Map to DTOs
            //var ProductsDto = new List<ProductDto>();
            //foreach (var product in ProductsDomain) 
            //{ 
            //    ProductsDto.Add(new ProductDto 
            //    {  ProductId = product.ProductId,
            //        ProductName=product.ProductName,
            //        ProductPrice=product.ProductPrice,
            //        DateModified = product.DateModified
            //    });
            //}
            //var ProductsDto = mapper.Map<List<ProductDto>>(ProductsDomain);
            return Ok(query.ToList());

        }
    }
}
