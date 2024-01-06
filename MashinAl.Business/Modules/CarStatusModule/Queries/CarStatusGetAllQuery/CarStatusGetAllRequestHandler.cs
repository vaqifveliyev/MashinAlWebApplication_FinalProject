using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetAllQuery
{
    internal class CarStatusGetAllRequestHandler : IRequestHandler<CarStatusGetAllRequest, IEnumerable<CarStatus>>
    {
        private readonly ICarStatusRepository carStatusRepository;

        public CarStatusGetAllRequestHandler(ICarStatusRepository carStatusRepository)
        {
            this.carStatusRepository = carStatusRepository;
        }
        public async Task<IEnumerable<CarStatus>> Handle(CarStatusGetAllRequest request, CancellationToken cancellationToken)
        {
            var data = carStatusRepository.GetAll();
            return await data.ToListAsync(cancellationToken);
        }
    }
}
