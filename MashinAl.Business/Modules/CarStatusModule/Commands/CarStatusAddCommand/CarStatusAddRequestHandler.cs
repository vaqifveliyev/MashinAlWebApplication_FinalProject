using MashinAl.Business.Modules.CarModule.Commands.CarAddCommand;
using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusAddCommand
{
    internal class CarStatusAddRequestHandler : IRequestHandler<CarStatusAddRequest, CarStatus>
    {
        private readonly ICarStatusRepository carStatusRepository;

        public CarStatusAddRequestHandler(ICarStatusRepository carStatusRepository)
        {
            this.carStatusRepository = carStatusRepository;
        }
        public async Task<CarStatus> Handle(CarStatusAddRequest request, CancellationToken cancellationToken)
        {
            var carstatus = new CarStatus
            {
                Title = request.Title,
            };

            carStatusRepository.Add(carstatus);
            carStatusRepository.Save();

            return carstatus;
        }
    }
}
