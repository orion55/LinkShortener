using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Db.Infrastructure;
using MediatR;

namespace LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product
{
    public class UpdateProductCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
 
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, int>
        {
            private readonly LinkDbContext _context;
            
            public UpdateProductCommandHandler(LinkDbContext context)
            {
                _context = context;
            }
            
            public async Task<int> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = _context.Product.FirstOrDefault(a => a.Id == command.Id);
 
                if (product == null) return default;

                product.Name = command.Name;
                product.Price = command.Price;
                await _context.SaveChangesAsync(cancellationToken);
                return product.Id;
            }
        }
    }
}