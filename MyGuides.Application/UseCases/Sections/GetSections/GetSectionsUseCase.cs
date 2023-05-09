using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Sections.Queries;
using MyGuides.Domain.Entities.Sections.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Application.UseCases.Sections.GetSections
{
    public class GetSectionsUseCase : UseCase<GetSectionsQuery, List<SectionResult>>, IGetSectionsUseCase
    {
        public GetSectionsUseCase(IMediator mediator, INotificationService notificationService) 
            : base(mediator, notificationService)
        {
        }

        protected override async Task<List<SectionResult>> OnExecuteAsync(GetSectionsQuery request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken).ConfigureAwait(false);
    }
}
