using MyGuides.Domain.Entities.Banners;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Banners
{
    public interface IBannerRepository : IRepository<Banner, Guid>
    {
    }
}
