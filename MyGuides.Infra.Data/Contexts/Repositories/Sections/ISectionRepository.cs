using MyGuides.Domain.Entities.Sections;
using MyGuides.Infra.Data.Contexts.Repositories.Abstractions;

namespace MyGuides.Infra.Data.Contexts.Repositories.Sections
{
    public interface ISectionRepository : IRepository<Section, Guid>
    {
    }
}
