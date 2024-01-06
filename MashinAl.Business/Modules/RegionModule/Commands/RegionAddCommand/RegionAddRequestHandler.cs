using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Commands.RegionAddCommand
{
    internal class RegionAddRequestHandler : IRequestHandler<RegionAddRequest, Region>
    {
        private readonly IRegionRepository regionRepository;

        public RegionAddRequestHandler(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        public async Task<Region> Handle(RegionAddRequest request, CancellationToken cancellationToken)
        {
            var region = new Region
            {
                Title  = request.Title,
                ShortTitle = request.ShortTitle,
            };

            regionRepository.Add(region);
            regionRepository.Save();

            return region;
        }
    }
}
