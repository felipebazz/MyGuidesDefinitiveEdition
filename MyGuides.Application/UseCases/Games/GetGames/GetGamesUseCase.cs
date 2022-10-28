using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Games.Queries;
using MyGuides.Domain.Entities.Games.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Application.UseCases.Games.GetGames
{
    public class GetGamesUseCase : UseCase<IEnumerable<GameResult>>, IGetGamesUseCase
    {
        public GetGamesUseCase(IMediator mediator, INotificationService notificationService) 
            : base(mediator, notificationService)
        {
        }

        protected override async Task<IEnumerable<GameResult>> OnExecuteAsync(CancellationToken cancellationToken)
            => await _mediator.Send(new GetGamesQuery(), cancellationToken);
    }
}
