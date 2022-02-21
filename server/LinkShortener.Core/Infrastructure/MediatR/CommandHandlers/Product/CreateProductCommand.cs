using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Db.Infrastructure;
using MediatR;

namespace LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product
{
    public class CreateProductCommand: IRequest<int>
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
 
        public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, int>
        {
            private LinkDbContext context;
            
            public CreateProductCommandHandler(LinkDbContext context)
            {
                this.context = context;
            }
            
            public async Task<int> Handle(CreateProductCommand command, CancellationToken cancellationToken)
            {
                var product = new Models.Product.Product
                {
                    Name = command.Name,
                    Price = command.Price
                };

                context.Product.Add(product);
                await context.SaveChangesAsync(cancellationToken);
                return product.Id;
            }
        }
    }
}