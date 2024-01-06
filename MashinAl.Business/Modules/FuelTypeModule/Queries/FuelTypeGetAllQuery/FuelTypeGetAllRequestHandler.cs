using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.FuelTypeModule.Queries.FuelTypeGetAllQuery
{
    internal class FuelTypeGetAllRequestHandler : IRequestHandler<FuelTypeGetAllRequest, IEnumerable<FuelType>>
    {
        private readonly IFuelTypeRepository fuelTypeRepository;

        public FuelTypeGetAllRequestHandler(IFuelTypeRepository fuelTypeRepository)
        {
            this.fuelTypeRepository = fuelTypeRepository;
        }
        public async Task<IEnumerable<FuelType>> Handle(FuelTypeGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = fuelTypeRepository.GetAll();
            return await data.ToListAsync(cancellationToken);   
        }
    }
}
