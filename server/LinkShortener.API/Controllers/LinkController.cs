using System;
using System.Threading.Tasks;
using LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product;
using LinkShortener.Models.Common;
using LinkShortener.Models.LinkModels;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LinkShortener.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class LinkController: ControllerBase
    {
        private readonly IMediator _mediator;
        readonly ILogger<LinkController> _logger;
        
        public LinkController(ILogger<LinkController> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator;
        }
        
        [HttpPost]
        [Route(nameof(AddLink))]
        [ProducesResponseType(typeof(ResponseModel<LinkModel>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseModel<BadRequestModel>), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddLink(CreateProductCommand command)
        {
            _logger.LogInformation("Hello, world!");
            return Ok(await _mediator.Send(command));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            
            return Ok(await _mediator.Send(new GetAllProductQuery()));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            return Ok(await _mediator.Send(command));
        }
    }
}