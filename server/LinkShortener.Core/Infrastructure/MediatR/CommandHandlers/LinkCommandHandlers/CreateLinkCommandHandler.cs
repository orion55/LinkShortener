using System.Threading;
using System.Threading.Tasks;
using LinkShortener.Core.Infrastructure.MediatR.Commands.LinkCommands;
using LinkShortener.Models.Common;
using LinkShortener.Models.LinkModels;
using MediatR;
using OneOf;

namespace LinkShortener.Core.Infrastructure.MediatR.CommandHandlers.LinkCommandHandlers
{
    public class CreateLinkCommandHandler: IRequestHandler<CreateLinkCommand, OneOf<LinkModel, BadRequestModel>>
    {
        public CreateLinkCommandHandler()
        {
        }

        public async Task<OneOf<LinkModel, BadRequestModel>> Handle(CreateLinkCommand request,
            CancellationToken cancellationToken)
        {
            return new BadRequestModel
            {
                ErrorMessage = "Everything is bad!"
            };
        }
    }
}