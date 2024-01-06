using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Commands.FuelTypeEditCommand
{
    internal class FuelTypeEditRequestHandler : IRequestHandler<FuelTypeEditRequest, FuelType>
    {
        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeEditRequestHandler(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }
        public async Task<FuelType> Handle(FuelTypeEditRequest request, CancellationToken cancellationToken)
        {
            var fueltype = new FuelType
            {
                Id = request.Id,
                Name = request.Name,
            };  

            fuelTypeRepository.Edit(fueltype);
            fuelTypeRepository.Save();

            return fueltype;
        }
    }
}
