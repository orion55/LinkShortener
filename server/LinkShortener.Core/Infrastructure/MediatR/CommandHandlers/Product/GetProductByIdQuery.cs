using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Db.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product
{
    public class GetProductByIdQuery : IRequest<Models.Product.Product>
    {
        public int Id { get; set; }
        
        public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Models.Product.Product>
        {
            private readonly LinkDbContext _context;
            
            public GetProductByIdQueryHandler(LinkDbContext context)
            {
                this._context = context;
            }
            
            public async Task<Models.Product.Product> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                var product = await _context.Product.Where(a => a.Id == query.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken);
                return product;
            }
        }
    }
}