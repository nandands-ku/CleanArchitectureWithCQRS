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
        public ItemCategoryController(IMediator mediator)
        {
            _mediatR = mediator;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<ItemCategory>> Get()
        {
            var response = await _mediatR.Send(new GetAllItemCategoryQuery());
            return response;
        }
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ItemCategoryResponse> CreateCategory([FromBody] CreateItemCategoryCommand command)
        {
            var response = await _mediatR.Send(command);
            return response;
        }
    }
}
