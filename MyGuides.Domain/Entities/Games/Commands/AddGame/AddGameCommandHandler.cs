using AutoMapper;
using MediatR;
using MyGuides.Domain.Entities.Achievements;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Domain.Entities.Games.Commands.AddGame
{
    public class AddGameCommandHandler : IRequestHandler<AddGameCommand, GameResult>
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly INotificationService _notificationService;

        public AddGameCommandHandler(
            IMapper mapper,
            IGameRepository gameRepository,
            INotificationService notificationService)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _notificationService = notificationService;
        }

        public async Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            if (_gameRepository.Any(g => request.AppId.Equals(g.AppId)))
            {
                _notificationService.AddNotification(DomainValidationMessages.AddGameCommandHandler_Game_Exists);
                return default;
            }

            Game game = new Game(
                Guid.NewGuid(),
                request.Name,
                request.Version,
                request.AppId,
                request.Image,
                request.BackgroundImage);

            var teste = _mapper.Map<List<Achievement>>(new Tuple<IEnumerable<Steam.Api.Responses.Achievement>, Guid>(request.Achievements, game.Id));
            game.AddAchievement(teste);

            game.Validate();

            if (!game.Valid)
            {
                _notificationService.AddNotification(string.Format(DomainValidationMessages.AddGameCommandHandler_Game_Invalid, game.ValidationResult.Errors.Count));
                return default;
            }

            await _gameRepository.AddAsync(game, cancellationToken);
            return _mapper.Map<GameResult>(game);
        }
    }
}
