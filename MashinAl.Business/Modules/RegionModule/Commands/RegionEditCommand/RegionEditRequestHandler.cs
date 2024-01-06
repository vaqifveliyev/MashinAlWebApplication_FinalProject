using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Commands.RegionEditCommand
{
    internal class RegionEditRequestHandler : IRequestHandler<RegionEditRequest, Region>
    {
        private readonly IRegionRepository regionRepository;

        public RegionEditRequestHandler(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        public async Task<Region> Handle(RegionEditRequest request, CancellationToken cancellationToken)
        {
            var region = new Region
            {
                Id = request.Id,
                Title  = request.Title,
                ShortTitle = request.ShortTitle,
            };

            regionRepository.Edit(region);
            regionRepository.Save();

            return region;
        }
    }
}
