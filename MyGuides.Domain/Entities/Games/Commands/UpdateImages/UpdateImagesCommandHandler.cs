using AutoMapper;
using MediatR;
using MyGuides.Domain.Entities.Games.Repository;
using MyGuides.Domain.Entities.Games.Results;

namespace MyGuides.Domain.Entities.Games.Commands.UpdateImages
{
    public class UpdateImagesCommandHandler : IRequestHandler<UpdateImagesCommand, GameResult>
    {
        private readonly IMapper _mapper;
        private readonly IGameRepository _gameRepository;
        //private readonly INotificationService notificationService;

        public UpdateImagesCommandHandler(IGameRepository gameRepository, IMapper mapper)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public async Task<GameResult> Handle(UpdateImagesCommand request, CancellationToken cancellationToken)
        {
            var game = await _gameRepository.GetByIdAsync(request.GameId, cancellationToken);

            if (game is null)
            {
                //add notification
                return default;
            }

            game.SetImage(request.Image);
            game.SetBackgroundImage(request.BackgroundImage);

            await _gameRepository.UpdateAsync(game, cancellationToken);
            return _mapper.Map<GameResult>(game);
        }
    }
}
