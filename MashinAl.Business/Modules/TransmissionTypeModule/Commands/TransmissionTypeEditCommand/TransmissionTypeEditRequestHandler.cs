using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Commands.TransmissionTypeEditCommand
{
    internal class TransmissionTypeEditRequestHandler : IRequestHandler<TransmissionTypeEditRequest, TransmissionType>
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransmissionTypeEditRequestHandler(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }
        public async Task<TransmissionType> Handle(TransmissionTypeEditRequest request, CancellationToken cancellationToken)
        {
            var transmission = new TransmissionType
            {
                 Id = request.Id,
                 Name = request.Name,
            };

            transmissionTypeRepository.Edit(transmission);
            transmissionTypeRepository.Save();

            return transmission;
        }
    }
}
