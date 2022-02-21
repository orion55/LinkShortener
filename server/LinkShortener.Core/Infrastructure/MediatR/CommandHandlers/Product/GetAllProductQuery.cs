using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Db.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.Product
{
    public class GetAllProductQuery : IRequest<IEnumerable<Models.Product.Product>>
    {
        public class GetAllProductQueryHandler : IRequestHandler<GetAllProductQuery, IEnumerable<Models.Product.Product>>
        {
            private readonly LinkDbContext _context;
            
            public GetAllProductQueryHandler(LinkDbContext context)
            {
                this._context = context;
            }
            
            public async Task<IEnumerable<Models.Product.Product>> Handle(GetAllProductQuery query, CancellationToken cancellationToken)
            {
                var productList = await _context.Product.ToListAsync(cancellationToken: cancellationToken);
                return productList;
            }
        }
    }
}