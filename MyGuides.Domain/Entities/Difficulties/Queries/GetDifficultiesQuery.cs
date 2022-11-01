using MediatR;
using MyGuides.Domain.Entities.Difficulties.Results;

namespace MyGuides.Domain.Entities.Difficulties.Queries
{
    public class GetDifficultiesQuery : IRequest<IEnumerable<DifficultyResult>>
    {
        public string AppId { get; set; }
    }
}
