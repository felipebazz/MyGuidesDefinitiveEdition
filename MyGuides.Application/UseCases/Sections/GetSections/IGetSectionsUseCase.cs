using MyGuides.Domain.Entities.Sections;
using MyGuides.Domain.Entities.Sections.Queries;
using MyGuides.Domain.Entities.Sections.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.Sections.GetSections
{
    public interface IGetSectionsUseCase : INotifiableUseCase<GetSectionsQuery, List<SectionResult>>
    {
    }
}
