using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Domain.Entities.Games.Commands.UpdateImages
{
    public class UpdateImagesCommandHandler : IRequestHandler<UpdateImagesCommand, GameResult>
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        private readonly INotificationService _notificationService;

        public UpdateImagesCommandHandler(
            IMapper mapper,
            IGameRepository gameRepository,
            INotificationService notificationService)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
            _notificationService = notificationService;
        }

        public async Task<GameResult> Handle(UpdateImagesCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.GameId, cancellationToken, include: g => g.Include(x => x.Achievements));

            if (game is null)
            {
                _notificationService.AddNotification("cadastrar");
                return default;
            }

            game.SetImage(request.Image);
            game.SetBackgroundImage(request.BackgroundImage);

            if (!game.Validate())
            {
                _notificationService.AddNotification("cadastrar");
                return default;
            }

            await _gameRepository.UpdateAsync(game, cancellationToken);
            return _mapper.Map<GameResult>(game);
        }
    }
}
