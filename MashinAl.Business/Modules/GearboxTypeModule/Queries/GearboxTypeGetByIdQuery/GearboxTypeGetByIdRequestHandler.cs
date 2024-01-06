using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Queries.GearboxTypeGetByIdQuery
{
    internal class GearboxTypeGetByIdRequestHandler : IRequestHandler<GearboxTypeGetByIdRequest, GearboxType>
    {
        private readonly IGearBoxTypeRepository gearBoxTypeRepository;

        public GearboxTypeGetByIdRequestHandler(IGearBoxTypeRepository gearBoxTypeRepository)
        {
            this.gearBoxTypeRepository = gearBoxTypeRepository;
        }
        public async Task<GearboxType> Handle(GearboxTypeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = gearBoxTypeRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
