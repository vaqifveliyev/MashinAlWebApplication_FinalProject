using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeRemoveCommand
{
    internal class FuelTypeRemoveRequestHandler : IRequestHandler<FuelTypeRemoveRequest>
    {
        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeRemoveRequestHandler(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }
        public async Task Handle(FuelTypeRemoveRequest request, CancellationToken cancellationToken)
        {
            var fueltype = fuelTypeRepository.Get(m => m.Id == request.Id);
            fuelTypeRepository.Remove(fueltype);
            fuelTypeRepository.Save();
        }
    }
}
