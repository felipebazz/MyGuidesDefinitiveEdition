using MediatR;
using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.Achievements.Queries.GetAchievements;
using MyGuides.Domain.Entities.Achievements.Results;
using MyGuides.Notifications.Context;

namespace MyGuides.Application.UseCases.Achievements.GetAchievements
{
    public class GetAchievementsUseCase : UseCase<GetAchievementsQuery, IEnumerable<AchievementResult>>, IGetAchievementsUseCase
    {
        public GetAchievementsUseCase(IMediator mediator, INotificationService notificationService)
            : base(mediator, notificationService)
        {
        }

        protected override async Task<IEnumerable<AchievementResult>> OnExecuteAsync(GetAchievementsQuery request, CancellationToken cancellationToken)
            => await _mediator.Send(request, cancellationToken);
    }
}
