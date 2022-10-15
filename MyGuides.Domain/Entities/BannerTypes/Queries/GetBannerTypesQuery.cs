using MediatR;
using MyGuides.Domain.Entities.BannerTypes.Results;

namespace MyGuides.Domain.Entities.BannerTypes.Queries
{
    public class GetBannerTypesQuery : IRequest<IEnumerable<BannerTypeResult>>
    {
    }
}
