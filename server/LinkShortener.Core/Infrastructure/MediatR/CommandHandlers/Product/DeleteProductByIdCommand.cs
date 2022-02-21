using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Db.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product
{
    public class DeleteProductByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, int>
        {
            private readonly LinkDbContext _context;
            
            public DeleteProductByIdCommandHandler(LinkDbContext context)
            {
                this._context = context;
            }
            
            public async Task<int> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await _context.Product.Where(a => a.Id == command.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                _context.Product.Remove(product);
                await _context.SaveChangesAsync(cancellationToken);
                return product.Id;
            }
        }
    }
}