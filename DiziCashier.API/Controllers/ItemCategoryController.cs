using DiziCashier.Application.Commands;
using DiziCashier.Application.Queries;
using DiziCashier.Application.Response;
using DiziCashier.Core.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DiziCashier.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemCategoryController : ControllerBase
    {
        private readonly IMediator _mediatR;
        private ILogger<ItemCategoryController> _logger;
        public ItemCategoryController(IMediator mediator, ILogger<ItemCategoryController> logger)
        {
            _mediatR = mediator;
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<ItemCategory>> Get()
        {
            _logger.LogInformation("Getting All ItemCategories!");
            var response = await _mediatR.Send(new GetAllItemCategoryQuery());
            return response;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ItemCategoryResponse> CreateCategory([FromBody] CreateItemCategoryCommand command)
        {
            _logger.LogInformation("Create ItemCategory!");

            var response = await _mediatR.Send(command);
            return response;
        }
    }
}
