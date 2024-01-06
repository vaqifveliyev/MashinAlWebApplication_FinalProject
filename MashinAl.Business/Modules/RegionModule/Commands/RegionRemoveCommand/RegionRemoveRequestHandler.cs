using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.RegionModule.Commands.RegionRemoveCommand
{
    internal class RegionRemoveRequestHandler : IRequestHandler<RegionRemoveRequest>
    {
        private readonly IRegionRepository regionRepository;

        public RegionRemoveRequestHandler(IRegionRepository regionRepository)
        {
            this.regionRepository = regionRepository;
        }
        public async Task Handle(RegionRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = regionRepository.Get(m => m.Id == request.Id);
            regionRepository.Remove(data);
            regionRepository.Save();
        }
    }
}
