using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Queries.CarStatusGetByIdQuery
{
    internal class CarStatusGetByIdRequestHandler : IRequestHandler<CarStatusGetByIdRequest, CarStatus>
    {
        private readonly ICarStatusRepository carStatusRepository;

        public CarStatusGetByIdRequestHandler(ICarStatusRepository carStatusRepository)
        {
            this.carStatusRepository = carStatusRepository;
        }
        public async Task<CarStatus> Handle(CarStatusGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = carStatusRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
