using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusRemoveCommand
{
    internal class CarStatusRemoveRequestHandler : IRequestHandler<CarStatusRemoveRequest>
    {
        private readonly ICarStatusRepository carStatusRepository;

        public CarStatusRemoveRequestHandler(ICarStatusRepository carStatusRepository)
        {
            this.carStatusRepository = carStatusRepository;
        }
        public async Task Handle(CarStatusRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = carStatusRepository.Get(m => m.Id == request.Id);
            carStatusRepository.Remove(data);
            carStatusRepository.Save();
        }
    }
}
