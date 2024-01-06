using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetByIdQuery
{
    internal class FuelTypeGetByIdRequestHandler : IRequestHandler<FuelTypeGetByIdRequest, FuelType>
    {
        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeGetByIdRequestHandler(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }
        public async Task<FuelType> Handle(FuelTypeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = fuelTypeRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
