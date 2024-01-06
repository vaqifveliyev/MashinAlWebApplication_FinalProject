using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeAddCommand
{
    internal class GearboxTypeAddRequestHandler : IRequestHandler<GearboxTypeAddRequest, GearboxType>
    {
        private readonly IGearBoxTypeRepository gearBoxTypeRepository;

        public GearboxTypeAddRequestHandler(IGearBoxTypeRepository gearBoxTypeRepository)
        {
            this.gearBoxTypeRepository = gearBoxTypeRepository;
        }
        public async Task<GearboxType> Handle(GearboxTypeAddRequest request, CancellationToken cancellationToken)
        {
            var gearbox = new GearboxType
            {
                Name = request.Name,
            };

            gearBoxTypeRepository.Add(gearbox);
            gearBoxTypeRepository.Save();

            return gearbox;
        }
    }
}
