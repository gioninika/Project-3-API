using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Project.Data;
using Project.Models;
using Project.Repository;
using System.Net;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly ILogger<OrderController> _logger;
        private readonly ProjectDbContext _dbContext;
        private IOrderRepository _orderRepository;
        private readonly IMapper _mapper;
        private APIResponse _apiResponse;



        public OrderController(ILogger<OrderController> logger, ProjectDbContext dbContext, IMapper mapper, IOrderRepository orderRepository)
        {
            _logger = logger;
            _dbContext = dbContext;
            _mapper = mapper;
            _apiResponse = new APIResponse();
            _orderRepository = orderRepository;
        }

        [HttpGet("All", Name = "GetAllOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]


        public async Task<ActionResult<APIResponse>> GetAllOrderAsync()
        {
            try
            {
                _logger.LogInformation("GetAllOrder started working");

                List<Order> order = await _orderRepository.GetAllAsync();

                _apiResponse.Data = _mapper.Map<List<OrderDTO>>(order);
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
        public async Task<ActionResult<APIResponse>> CreateOrderAsync([FromBody] OrderDTO dto)
        {

            try
            {
                _logger.LogInformation("CreateOrder started Working");

                if (dto == null)
                    return BadRequest();

                Order order = _mapper.Map<Order>(dto);

                Order OrderAfterCreation = await _orderRepository.CreateAsync(order);

                dto.Id = OrderAfterCreation.Id;

                _apiResponse.Data = dto;
                _apiResponse.status = true;
                _apiResponse.StatusCode = HttpStatusCode.OK;

                return Ok(OrderAfterCreation);
            }
            catch (Exception ex)
            {
                _apiResponse.status = false;
                _apiResponse.StatusCode = HttpStatusCode.InternalServerError;

                return _apiResponse;
            }
        }

        [HttpDelete("{id:int}", Name = "DeleteProductInOrder")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<APIResponse>> DeleteOrderAsync(int id)
        {
            try
            {
                _logger.LogInformation("DeleteProductInOrder started Working");

                if (id <= 0)
                    return BadRequest();

                Order oder = await _orderRepository.GetByAsync(x => x.Id == id);

                if (oder == null)
                    return NotFound();

                await _orderRepository.DeleteAsync(oder);

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
