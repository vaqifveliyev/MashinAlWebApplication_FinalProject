using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.GearboxTypeModule.Commands.GearboxTypeRemoveCommand
{
    internal class GearboxTypeRemoveRequestHandler : IRequestHandler<GearboxTypeRemoveRequest>
    {
        private readonly IGearBoxTypeRepository gearBoxTypeRepository;

        public GearboxTypeRemoveRequestHandler(IGearBoxTypeRepository gearBoxTypeRepository)
        {
            this.gearBoxTypeRepository = gearBoxTypeRepository;
        }
        public async Task Handle(GearboxTypeRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = gearBoxTypeRepository.Get(m => m.Id == request.Id);
            gearBoxTypeRepository.Remove(data);
            gearBoxTypeRepository.Save();
        }
    }
}
