using MyGuides.Domain.Abstractions.Entities;

namespace MyGuides.Domain.Entities.BannerTypes
{
    public abstract class BannerType : Entity<int>
    {
        public string Name { get; set; }

        public BannerType(int id, string name)
            : base(id)
        {
            Name = name;
        }

        protected BannerType() { }
    }
}
