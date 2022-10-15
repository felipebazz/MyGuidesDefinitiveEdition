using MyGuides.Domain.Entities.BannerTypes;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.BannerTypes
{
    public interface IBannerTypeRepository : IReadOnlyRepository<BannerType>
    {
    }
}
