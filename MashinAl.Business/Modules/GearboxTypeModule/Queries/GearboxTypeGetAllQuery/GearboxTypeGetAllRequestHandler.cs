using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetAllQuery
{
    internal class GearboxTypeGetAllRequestHandler : IRequestHandler<GearboxTypeGetAllRequest, IEnumerable<GearboxType>>
    {
        private readonly IGearBoxTypeRepository gearBoxTypeRepository;

        public GearboxTypeGetAllRequestHandler(IGearBoxTypeRepository gearBoxTypeRepository)
        {
            this.gearBoxTypeRepository = gearBoxTypeRepository;
        }
        public async Task<IEnumerable<GearboxType>> Handle(GearboxTypeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data  = gearBoxTypeRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
