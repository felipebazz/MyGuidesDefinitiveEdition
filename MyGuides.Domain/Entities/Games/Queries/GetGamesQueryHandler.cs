using AutoMapper;
using MediatR;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Queries
{
    public class GetGamesQueryHandler : IRequestHandler<GetGamesQuery, IEnumerable<GameResult>>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;
        public GetGamesQueryHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }
        public async Task<IEnumerable<GameResult>> Handle(GetGamesQuery request, CancellationToken cancellationToken)
        {
            var games = await _gameRepository.GetAsync(cancellationToken);

            return _mapper.Map<List<GameResult>>(games.OrderBy(o => o.UpdateDate ?? o.ImportDate));
        }
    }
}
