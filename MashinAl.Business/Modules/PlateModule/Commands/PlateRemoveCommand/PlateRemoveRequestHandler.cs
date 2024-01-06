using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.PlateModule.Commands.PlateRemoveCommand
{
    internal class PlateRemoveRequestHandler : IRequestHandler<PlateRemoveRequest>
    {
        private readonly IPlateRepository plateRepository;

        public PlateRemoveRequestHandler(IPlateRepository plateRepository)
        {
            this.plateRepository = plateRepository;
        }
        public async Task Handle(PlateRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = plateRepository.Get(m => m.Id == request.Id);
            plateRepository.Remove(data);
            plateRepository.Save();
        }
    }
}
