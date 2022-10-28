using MyGuides.Domain.Entities.BannerTypes.Results;
using MyGuides.Notifications.UseCaseAbstractions;

namespace MyGuides.Application.UseCases.BannerTypes.GetBannerTypes
{
    public interface IGetBannerTypesUseCase : INotifiableUseCase<IEnumerable<BannerTypeResult>>
    {
    }
}
