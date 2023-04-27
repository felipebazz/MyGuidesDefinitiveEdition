using AutoMapper;
using MediatR;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Commands.AddGame
{
    public class AddGameCommandHandler : IRequestHandler<AddGameCommand, GameResult>
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public AddGameCommandHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _gameRepository = gameRepository;
            _mapper = mapper;
        }

        public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            //verificar se já existe no banco via appId
            if (_gameRepository.Any(g => request.AppId.Equals(g.AppId, StringComparison.InvariantCultureIgnoreCase)))
            {
                //Add notification
            }

            Game game = new Game(
                Guid.NewGuid(),
                request.Name,
                request.Version,
                request.AppId,
                request.Image,
                request.BackgroundImage);

            game.AddAchievement(_mapper.Map<List<Achievement>>(request.Achievements));

            game.Validate();

            if (!game.Valid)
            {
                //add notification
            }

            await _gameRepository.AddAsync(game, cancellationToken);
            return _mapper.Map<GameResult>(game);
        }
    }
}
