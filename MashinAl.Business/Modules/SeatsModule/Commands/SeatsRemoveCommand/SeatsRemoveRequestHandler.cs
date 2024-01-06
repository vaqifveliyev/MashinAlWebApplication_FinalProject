using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.SeatsModule.Commands.SeatsRemoveCommand
{
    internal class SeatsRemoveRequestHandler : IRequestHandler<SeatsRemoveRequest>
    {
        private readonly ISeatRepository seatRepository;

        public SeatsRemoveRequestHandler(ISeatRepository seatRepository)
        {
            this.seatRepository = seatRepository;
        }
        public async Task Handle(SeatsRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = seatRepository.Get(m => m.Id == request.Id);
            seatRepository.Remove(data);
            seatRepository.Save();
        }
    }
}
