using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Queries.RegionGetByIdQuery
{
    internal class RegionGetByIdRequestHandler : IRequestHandler<RegionGetByIdRequest, Region>
    {
        private readonly IRegionRepository regionRepository;

        public RegionGetByIdRequestHandler(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        public async Task<Region> Handle(RegionGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = regionRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
