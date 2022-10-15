using MediatR;
using MyGuides.Domain.Entities.BannerTypes.Repository;
using MyGuides.Domain.Entities.BannerTypes.Results;

namespace MyGuides.Domain.Entities.BannerTypes.Queries
{
    public class GetBannerTypesQueryHandler : IRequestHandler<GetBannerTypesQuery, IEnumerable<BannerTypeResult>>
    {
        private readonly IBannerTypeRepository _bannerTypeRepository;

        public GetBannerTypesQueryHandler(IBannerTypeRepository bannerTypeRepository)
        {
            _bannerTypeRepository = bannerTypeRepository;
        }

        public async Task<IEnumerable<BannerTypeResult>> Handle(GetBannerTypesQuery request, CancellationToken cancellationToken)
        {
            var bannerTypes = await _bannerTypeRepository.GetAsync(c => !c.Hidden, cancellationToken);

            return bannerTypes?
                .Select(types => new BannerTypeResult
                {
                    Id = types.Id,
                    Name = types.Name
                }).OrderBy(o => o.Name);
        }
    }
}
