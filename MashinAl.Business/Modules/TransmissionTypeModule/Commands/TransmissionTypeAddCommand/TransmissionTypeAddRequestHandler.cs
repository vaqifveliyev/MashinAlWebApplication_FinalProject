using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeAddCommand
{
    internal class TransmissionTypeAddRequestHandler : IRequestHandler<TransmissionTypeAddRequest, TransmissionType>
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransmissionTypeAddRequestHandler(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }
        public async Task<TransmissionType> Handle(TransmissionTypeAddRequest request, CancellationToken cancellationToken)
        {
            var transmission = new TransmissionType
            {
                Name = request.Name,
            };

            transmissionTypeRepository.Add(transmission);
            transmissionTypeRepository.Save();

            return transmission;
        }
    }
}
