using MediatR;
using MyGuides.Domain.Entities.Sections.Results;

namespace MyGuides.Domain.Entities.Sections.Commands.AddSection
{
    public class AddSectionCommand : IRequest<SectionResult>
    {
    }
}
