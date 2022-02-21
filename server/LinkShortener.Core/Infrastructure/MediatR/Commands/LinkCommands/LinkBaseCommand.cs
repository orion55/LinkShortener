using LinkShortener.Models.Common;
using LinkShortener.Models.LinkModels;
using MediatR;
using OneOf;

namespace LinkShortener.Core.Infrastructure.MediatR.Commands.LinkCommands
{
	public class LinkBaseCommand: IRequest<OneOf<LinkModel, BadRequestModel>>
	{
		public LinkBaseCommand(LinkModel model)
		{
			Model = model;
		}

		public LinkModel Model { get; set; }
	}
}
