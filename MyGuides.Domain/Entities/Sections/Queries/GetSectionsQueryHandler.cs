using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Achievements.Repositories;
using MyGuides.Domain.Entities.Sections.Repository;
using MyGuides.Domain.Entities.Sections.Results;

namespace MyGuides.Domain.Entities.Sections.Queries
{
    public class GetSectionsQueryHandler : IRequestHandler<GetSectionsQuery, List<SectionResult>>
    {
        private readonly ISectionRepository _sectionRepository;

        public GetSectionsQueryHandler(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        //public async Task<IEnumerable<SectionResult>> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        public async Task<List<SectionResult>> Handle(GetSectionsQuery request, CancellationToken cancellationToken)
        {
            var sections = await _sectionRepository.GetAsync(
                x => x.Achievements.First().GameId == request.GameId, 
                cancellationToken,
                include: source => source.Include(d => d.Achievements.Select(d => d.Difficulty)));

            return new List<SectionResult>();
        }
    }
}
