using MashinAl.Infastructure.Entities;
using MashinAl.Infastructure.Repositories;
using MediatR;

namespace MashinAl.Business.Modules.TransmissionTypeModule.Queries.TransmissionTypeGetByIdQuery
{
    internal class TransmissionTypeGetByIdRequestHandler : IRequestHandler<TransmissionTypeGetByIdRequest, TransmissionType>
    {
        private readonly ITransmissionTypeRepository transmissionTypeRepository;

        public TransmissionTypeGetByIdRequestHandler(ITransmissionTypeRepository transmissionTypeRepository)
        {
            this.transmissionTypeRepository = transmissionTypeRepository;
        }
        public async Task<TransmissionType> Handle(TransmissionTypeGetByIdRequest request, CancellationToken cancellationToken)
        {
            var data = transmissionTypeRepository.Get(m => m.Id == request.Id);
            return data;
        }
    }
}
