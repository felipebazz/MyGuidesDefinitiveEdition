using MyGuides.Domain.Entities.BannerTypes;
using MyGuides.Domain.Entities.BannerTypes.Repository;
using MyGuides.Infra.Data.Contexts.Database;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.BannerTypes
{
    public class BannerTypeRepository : ReadOnlyRepository<BannerType, int>, IBannerTypeRepository
    {
        public BannerTypeRepository(MyGuidesContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
