using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.CarStatusModule.Commands.CarStatusEditCommand
{
    internal class CarStatusEditRequestHandler : IRequestHandler<CarStatusEditRequest, CarStatus>
    {
        private readonly ICarStatusRepository carStatusRepository;

        public CarStatusEditRequestHandler(ICarStatusRepository carStatusRepository)
        {
            this.carStatusRepository = carStatusRepository;
        }
        public async Task<CarStatus> Handle(CarStatusEditRequest request, CancellationToken cancellationToken)
        {
            var carstatus = new CarStatus
            {
                Id = request.Id,
                Title = request.Title,
            };

            carStatusRepository.Edit(carstatus);
            carStatusRepository.Save();

            return carstatus;
        }
    }
}
