using MyGuides.Application.Abstractions;
using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases
{
    public interface IGetBannerTypesUseCase : INotifiableUseCase<IEnumerable<BannerTypeResult>>
    {
    }
}
