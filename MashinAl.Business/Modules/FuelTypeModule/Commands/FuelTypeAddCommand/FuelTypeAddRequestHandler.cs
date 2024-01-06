using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeAddCommand
{
    internal class FuelTypeAddRequestHandler : IRequestHandler<FuelTypeAddRequest, FuelType>
    {
        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeAddRequestHandler(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }
        public  async Task<FuelType> Handle(FuelTypeAddRequest request, CancellationToken cancellationToken)
        {
            var fueltype = new FuelType
            {
                Name = request.Name,
            };

            fuelTypeRepository.Add(fueltype);
            fuelTypeRepository.Save();
            return fueltype;
        }
    }
}
