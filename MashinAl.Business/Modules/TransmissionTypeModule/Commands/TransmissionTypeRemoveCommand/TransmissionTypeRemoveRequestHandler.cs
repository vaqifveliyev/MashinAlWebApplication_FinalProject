using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeRemoveCommand
{
    internal class TransmissionTypeRemoveRequestHandler : IRequestHandler<TransmissionTypeRemoveRequest>
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransmissionTypeRemoveRequestHandler(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }
        public async Task Handle(TransmissionTypeRemoveRequest request, CancellationToken cancellationToken)
        {
            var data = transmissionTypeRepository.Get(m => m.Id == request.Id);
            transmissionTypeRepository.Remove(data);
            transmissionTypeRepository.Save();
        }
    }
}
