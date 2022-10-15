using Microsoft.EntityFrameworkCore;
using MyGuides.Domain.Entities.Sections;
using MyGuides.Domain.Entities.Sections.Repository;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Sections
{
    public class SectionRepository : Repository<Section, Guid>, ISectionRepository
    {
        public SectionRepository(DbContext dbContext) 
            : base(dbContext)
        {
        }
    }
}
