using MediatR;
using MyGuides.Domain.Entities.Difficulties.Repository;
using MyGuides.Domain.Entities.Difficulties.Results;

namespace MyGuides.Domain.Entities.Difficulties.Queries
{
    public class GetDifficultiesQueryHandler : IRequestHandler<GetDifficultiesQuery, IEnumerable<DifficultyResult>>
    {
        private readonly IDifficultyRepository _difficultyRepository;

        public GetDifficultiesQueryHandler(IDifficultyRepository difficultyRepository)
        {
            _difficultyRepository = difficultyRepository;
        }

        public async Task<IEnumerable<DifficultyResult>> Handle(GetDifficultiesQuery request, CancellationToken cancellationToken)
        {
            //var difficulties = await _difficultyRepository.GetAsync(d => d.)


            throw new NotImplementedException();
        }
    }
}
