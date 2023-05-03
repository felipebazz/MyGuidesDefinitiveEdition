using MediatR;
using MyGuides.Domain.Entities.Sections.Results;

namespace MyGuides.Domain.Entities.Sections.Queries
{
    public class GetSectionsQuery : IRequest<List<Section>>
    {
        public Guid GameId { get; set; }

        public GetSectionsQuery(Guid gameId)
        {
            GameId = gameId;
        }
    }
}
