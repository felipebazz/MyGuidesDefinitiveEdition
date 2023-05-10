using MyGuides.Domain.Entities.Sections.Requests;
using MyGuides.Domain.Entities.Sections.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Sections.AddSection
{
    public interface IAddSectionUseCase : INotifiableUseCase<AddSectionRequest, SectionResult>
    {
    }
}
