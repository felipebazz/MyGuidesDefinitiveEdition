using MediatR;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Commands
{
    public class AddGameCommandHandler : IRequestHandler<AddGameCommand, GameResult>
    {
        private readonly IGameRepository _gameRepository;

        public AddGameCommandHandler(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            //verificar se já existe no banco via appId
            if (_gameRepository.Any(g => g.AppId == request.AppId))
            {
                //Add notification
            }

            Game game = new Game(
                Guid.NewGuid(),
                request.Name,
                request.Version,
                request.AppId);

            game.AddAchievement(request.Achievements);

            game.Validate();

            if (!game.Valid)
            {
                //add notification
            }

            await _gameRepository.AddAsync(game, cancellationToken);

            return new GameResult()
            {
                AppId = game.AppId,
                Name = game.Name,
                Id = game.Id,
                ImportDate = game.ImportDate,
                UpdateDate = game.UpdateDate.Value
            };

            throw new NotImplementedException();
        }
    }
}
