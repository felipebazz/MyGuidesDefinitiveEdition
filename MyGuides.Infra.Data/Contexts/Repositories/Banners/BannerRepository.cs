using MyGuides.Domain.Entities.Banners;
using MyGuides.Domain.Entities.Banners.Repository;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Banners
{
    public class BannerRepository : Repository<Banner, Guid>, IBannerRepository
    {
        public BannerRepository(MyGuidesContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
