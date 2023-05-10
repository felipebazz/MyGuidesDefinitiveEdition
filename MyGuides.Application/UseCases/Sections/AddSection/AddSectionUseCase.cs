using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Sections.Commands.AddSection;
using MyGuides.Domain.Entities.Sections.Requests;
using MyGuides.Domain.Entities.Sections.Results;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Notifications.Context;

namespace MyGuides.Application.UseCases.Sections.AddSection
{
    public class AddSectionUseCase : TransactionalUseCase<AddSectionRequest, SectionResult>, IAddSectionUseCase
    {
        public AddSectionUseCase(
            IMediator mediator, 
            IUnitOfWork unitOfWork, 
            INotificationService notificationService) 
            : base(mediator, unitOfWork, notificationService)
        {
        }

        protected override Task<SectionResult> OnExecuteAsync(AddSectionRequest request, CancellationToken cancellationToken)
        {


            var command = new AddSectionCommand();

            throw new NotImplementedException();
        }
    }
}
