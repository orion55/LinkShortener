using System.Threading.Tasks;
using LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController: ControllerBase
    {
        private IMediator mediator;
        public ProductController(IMediator mediator)
        {
            this.mediator = mediator;
        }
 
        [HttpPost]
        public async Task<IActionResult> Create(CreateProductCommand command)
        {
            return Ok(await mediator.Send(command));
        }
        
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await mediator.Send(new GetAllProductQuery()));
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await mediator.Send(new GetProductByIdQuery { Id = id }));
        }
        
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update(int id, UpdateProductCommand command)
        {
            command.Id = id;
            return Ok(await mediator.Send(command));
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await mediator.Send(new DeleteProductByIdCommand { Id = id }));
        }
    }
}