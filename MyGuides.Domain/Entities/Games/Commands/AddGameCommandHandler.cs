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

        public Task<GameResult> Handle(AddGameCommand request, CancellationToken cancellationToken)
        {
            //verificar se já existe no banco via appId
            if (_gameRepository.Any(g => g.AppId == request.AppId))
            {
                //Add notification
            }


            throw new NotImplementedException();
        }
    }
}
