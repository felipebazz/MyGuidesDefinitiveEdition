using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Sections;
using MyGuides.Domain.Entities.Sections.Queries;
using MyGuides.Notifications.Context;

namespace MyGuides.Application.UseCases.Sections.GetSections
{
    public class GetSectionsUseCase : UseCase<GetSectionsQuery, List<Section>>, IGetSectionsUseCase
    {
        public GetSectionsUseCase(IMediator mediator, INotificationService notificationService) 
            : base(mediator, notificationService)
        {
        }

        protected override async Task<List<Section>> OnExecuteAsync(GetSectionsQuery request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
    }
}
