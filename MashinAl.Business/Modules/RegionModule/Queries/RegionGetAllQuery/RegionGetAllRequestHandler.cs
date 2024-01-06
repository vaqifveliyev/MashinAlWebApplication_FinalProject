using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Queries.RegionGetAllQuery
{
    internal class RegionGetAllRequestHandler : IRequestHandler<RegionGetAllRequest, IEnumerable<Region>>
    {
        private readonly IRegionRepository regionRepository;

        public RegionGetAllRequestHandler(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        public async Task<IEnumerable<Region>> Handle(RegionGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = regionRepository.GetAll().OrderBy(m => m.Title);
            return data;
        }
    }
}
