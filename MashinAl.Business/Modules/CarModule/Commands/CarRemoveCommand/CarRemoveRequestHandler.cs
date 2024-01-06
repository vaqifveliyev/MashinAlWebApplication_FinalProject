using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CarModule.Commands.CarRemoveCommand
{
    internal class CarRemoveRequestHandler : IRequestHandler<CarRemoveRequest>
    {
        private readonly ICarRepository carRepository;

        public CarRemoveRequestHandler(ICarRepository carRepository)
        {
            this.carRepository = carRepository;
        }
        public async Task Handle(CarRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = carRepository.Get(m => m.Id == request.Id);

            carRepository.Remove(data);
            carRepository.Save();

        }
    }
}
