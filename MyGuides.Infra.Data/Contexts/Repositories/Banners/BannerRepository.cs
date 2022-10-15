using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Banners;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Banners
{
    public class BannerRepository : Repository<Banner, Guid>, IBannerRepository
    {
        public BannerRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
