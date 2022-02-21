using LinkShortener.Models.LinkModels;

namespace LinkShortener.Core.Infrastructure.MediatR.Commands.LinkCommands
{
    public class CreateLinkCommand: LinkBaseCommand
    {
        public CreateLinkCommand(LinkModel model) : base(model)
        {
        }
    }
}