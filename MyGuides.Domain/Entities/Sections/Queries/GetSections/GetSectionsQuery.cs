using MediatR;
using MyGuides.Domain.Entities.Sections.Results;

namespace MyGuides.Domain.Entities.Sections.Queries.GetSections
{
    public class GetSectionsQuery : IRequest<List<SectionResult>>
    {
        public Guid GameId { get; set; }

        public GetSectionsQuery(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
