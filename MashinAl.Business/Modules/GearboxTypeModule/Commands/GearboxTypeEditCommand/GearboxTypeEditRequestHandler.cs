using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeEditCommand
{
    internal class GearboxTypeEditRequestHandler : IRequestHandler<GearboxTypeEditRequest, GearboxType>
    {
        private readonly IGearBoxTypeRepository gearBoxTypeRepository;

        public GearboxTypeEditRequestHandler(IGearBoxTypeRepository gearBoxTypeRepository)
        {
            this.gearBoxTypeRepository = gearBoxTypeRepository;
        }
        public async Task<GearboxType> Handle(GearboxTypeEditRequest request, CancellationToken cancellationToken)
        {
            var gearbox = new GearboxType
            {
                Id = request.Id,
                Name = request.Name,
            };

            gearBoxTypeRepository.Edit(gearbox);
            gearBoxTypeRepository.Save();

            return gearbox;
        }
    }
}
