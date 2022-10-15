using MyGuides.Domain.Abstractions.Entities;

namespace MyGuides.Domain.Entities.BannerTypes
{
    public abstract class BannerType : Entity<int>
    {
        public string Name { get; set; }
        public bool Hidden { get; set; }

        public BannerType(int id, string name, bool hidden = false)
            : base(id)
        {
            Name = name;
            Hidden = hidden;
        }

        protected BannerType() { }
    }
}
