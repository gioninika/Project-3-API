using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Repository;
using System.Net;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly ProjectDbContext _dbContext;
        private IProductRepository _productRepository;
        private readonly IMapper _mapper;
        private APIResponse _apiResponse;



        public ProductController(ILogger<ProductController> logger, ProjectDbContext dbContext, IMapper mapper, IProductRepository productrepository)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
            _apiResponse = new APIResponse();
            _productRepository = productrepository;
        }

        //calculate total

        [HttpGet("All", Name = "GetAllProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public async Task<ActionResult<APIResponse>> GetAllProductAsync()
        {
            try
            {
                _logger.LogInformation("GetAllProduct started working");

                List<Product> product = await _productRepository.GetAllAsync();

                _apiResponse.Data = _mapper.Map<List<ProductDTO>>(product);
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.status = true;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }


        [HttpPost("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<APIResponse>> AddToStockAsync([FromBody] ProductDTO dto)
        {

            try
            {
                _logger.LogInformation("CreateProduct started Working");

                if (dto == null)
                    return BadRequest();

                Product product = _mapper.Map<Product>(dto);

                Product productAfterCreation = await _productRepository.CreateAsync(product);

                dto.Id = productAfterCreation.Id;

                _apiResponse.Data = dto;
                _apiResponse.status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return _apiResponse.Data;
            }
            catch (Exception ex)
            {
                _apiResponse.status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteProduct")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> RemoveFromStockAsync(int id)
        {
            try
            {
                _logger.LogInformation("DeleteProductFromStock started Working");

                if (id <= 0)
                    return BadRequest();

                Product product = await _productRepository.GetByAsync(x => x.Id == id);

                if (product == null)
                    return NotFound();

                await _productRepository.DeleteAsync(product);

                _apiResponse.Data = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;
                _apiResponse.status = true;

                return Ok(_apiResponse);
            }
            catch (Exception ex)
            {
                _apiResponse.status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;
                _apiResponse.Errors.Add(ex.Message);

                return _apiResponse;
            }
        }
    }
}
